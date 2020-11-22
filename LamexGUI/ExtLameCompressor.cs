using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace LamexGUI
{
    public class ExtLameCompressor : IMp3Compressor
    {
        private class compressTask
        {
            public string WavFileName;
            public string OutFileName;
            public int QuelityPreset;
            public bool DeleteOrigin;
        }

        private static ConcurrentQueue<compressTask> filesList = new ConcurrentQueue<compressTask>();
        private static int processes = 0;
        private static string lamePath = "lame";
        private static string lameAddParamsRunning = "--silent -t";
        private static string lameAddParamsScript = "";
        private static ScriptMode _scriptMode;
        private static List<string> scriptText = new List<string>();

        public void Compress(string wavFile, string outFile, int qualityPreset, bool deleteOrigin, ScriptMode scriptMode)
        {
            filesList.Enqueue(new compressTask
            {
                WavFileName = wavFile,
                OutFileName = outFile,
                QuelityPreset = qualityPreset,
                DeleteOrigin = deleteOrigin
            });
            _scriptMode = scriptMode;
        }

        private static string GetQuelitySettingsParam(int qualityPreset)
        {
            var cbrBitrates = new int[] { 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320 };

            string s = "";
            if (qualityPreset < 100)
            {
                //cbr
                s = s + "-b " + cbrBitrates[qualityPreset - 1].ToString();
            }
            else
            {
                //vbr
                if (qualityPreset < 115)
                {
                    string VPreset = "6";
                    string lowBitrate = "64";

                    if (qualityPreset < 107)
                    {
                        VPreset = "6";
                        if (qualityPreset <= 104)
                        {
                            lowBitrate = "32";
                            if (qualityPreset == 101)
                                VPreset = "7";
                        }
                        else
                            lowBitrate = "64";
                    }
                    else
                    if (qualityPreset <= 110)
                    {
                        VPreset = "4";
                        lowBitrate = "96";
                    }
                    else
                    if (qualityPreset <= 114)
                    {
                        VPreset = "3";
                        lowBitrate = "192";
                    }

                    s += $"-V{ VPreset } -b { lowBitrate } -B { cbrBitrates[qualityPreset - 101].ToString() }";
                }
                else
                    s += "-V1 -b 224 -B 320";
            }
            return s;
        }

        public static async Task RunAsync(CancellationToken cancellationToken, int threadsCount)
        {
            bool ended = true;
            while (!cancellationToken.IsCancellationRequested)
            {
                if (processes < threadsCount)
                {
                    compressTask wavFile = new compressTask();
                    if (filesList.TryDequeue(out wavFile))
                    {
                        ended = false;
                        if (_scriptMode != ScriptMode.ScriptOnly)
                        {
                            var t = new Task(() =>
                            {
                                processes++;
                                var fileDate = File.GetLastWriteTime(wavFile.WavFileName);
                                Process p = Process.Start(new ProcessStartInfo
                                {
                                    Arguments = "\"" + wavFile.WavFileName + "\" \"" + wavFile.OutFileName + "\" " + GetQuelitySettingsParam(wavFile.QuelityPreset) + " " + lameAddParamsRunning,
                                    CreateNoWindow = true,
                                    FileName = lamePath,
                                    RedirectStandardInput = false,
                                    RedirectStandardOutput = false,
                                    WindowStyle = ProcessWindowStyle.Hidden
                                });
                                p.WaitForExit();

                                if (File.Exists(wavFile.OutFileName))
                                {
                                    File.SetLastWriteTime(wavFile.OutFileName, fileDate);
                                    File.SetCreationTime(wavFile.OutFileName, fileDate);

                                    if (wavFile.DeleteOrigin)
                                    {
                                        File.Delete(wavFile.WavFileName);
                                    }
                                }
                                processes--;
                            });
                            t.Start();
                            if (processes > threadsCount)
                                await Task.WhenAll(t);
                        }
                        if (_scriptMode > ScriptMode.None)
                        {
                            scriptText.Add(lamePath + " " + "\"" + wavFile.WavFileName + "\" \"" + wavFile.OutFileName + "\" " + GetQuelitySettingsParam(wavFile.QuelityPreset) + " " + lameAddParamsScript);
                            scriptText.Add("touch \"" + wavFile.WavFileName + "\" --reference=\"" + wavFile.OutFileName + "\"");
                            if (wavFile.DeleteOrigin)
                            {
                                scriptText.Add("del \"" + wavFile.WavFileName + "\"");
                            }
                            scriptText.Add("");
                        }
                    }
                    else
                    {
                        if (_scriptMode > ScriptMode.None && !ended)
                        {
                            File.WriteAllLines("BatchScript.bat", scriptText, Encoding.GetEncoding(866));
                        }
                        ended = true;
                    }
                }
                await Task.Delay(1);
            }
        }

        public string GetCodecParams(int qualityPreset)
        {
            return GetQuelitySettingsParam(qualityPreset);
        }

        public int GetPoolCapacity()
        {
            return filesList.Count + processes;
        }
    }
}
