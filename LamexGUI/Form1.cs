using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace LamexGUI
{
    public partial class Form1 : Form
    {
        IMp3Compressor extLame = new ExtLameCompressor();
        bool msbDeleteOrigin = true;
        List<string> FilesList = new List<string>();

        public Form1()
        {
            InitializeComponent();

            lbQualityPreset.Text = trbQuality.Value.ToString();
            spCodecParams.Text = extLame.GetCodecParams(chCBR.Checked ? trbQuality.Value : trbQuality.Value + 100);
            cbScript.SelectedIndex = 0;
        }

        private void DirSearch(string sDir, bool Recursive)
        {
            string searchMask = "*.wav";
            try
            {
                if (Recursive)
                {
                    foreach (string d in Directory.GetDirectories(sDir))
                    {
                        DirSearch(d, true);
                        Application.DoEvents();
                    }
                }
                FilesList.AddRange(Directory.GetFiles(sDir, searchMask));
            }
            catch
            {
                ///
            }
        }

        private string IncludeBackslash(string dir)
        {
            string d = dir;
            if (!dir.EndsWith(Path.DirectorySeparatorChar.ToString()))
                d += Path.DirectorySeparatorChar;
            return d;
        }

        private void InterfaceSetEnable(bool EnableMode)
        {
            btConvert.Enabled = EnableMode;
            trbQuality.Enabled = EnableMode;
            btChangeDir.Enabled = EnableMode;
            chDeleteOrigin.Enabled = EnableMode;
            cbScript.Enabled = EnableMode;
            chCBR.Enabled = EnableMode;
            chShutdownWhenDone.Enabled = EnableMode;
        }

        private void btConvert_Click(object sender, EventArgs e)
        {
            InterfaceSetEnable(false);
            bool delOrig = chDeleteOrigin.Checked;
            if (msbDeleteOrigin)
            {
                delOrig = MessageBox.Show("Удалять оригинал?", "Удалять оригинал?", MessageBoxButtons.YesNo) == DialogResult.Yes;
            }

            FilesList.Clear();
            string dir = IncludeBackslash(tbDirectory.Text);
            DirSearch(dir, chRecursive.Checked);
            var files = FilesList.Where(p => !lbExcludePatterns.Items.Cast<string>().Any() || lbExcludePatterns.Items.Cast<string>().Any(t => !p.Contains(t.ToLower())));
            if (MessageBox.Show($"Найдено { files.Count() } файлов.", "Продолжить?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var scm = (ScriptMode)cbScript.SelectedIndex;
                foreach (var f in files)
                {
                    string fileName = IncludeBackslash(Path.GetDirectoryName(f)) + Path.GetFileNameWithoutExtension(f) + ".mp3";
                    extLame.Compress(f, fileName, chCBR.Checked ? trbQuality.Value : trbQuality.Value + 100, delOrig, scm);
                }

                timer1.Enabled = true;
                var tc = ExtLameCompressor.RunAsync(new System.Threading.CancellationToken(), Environment.ProcessorCount);
            }
            else
                InterfaceSetEnable(true);
        }

        private void trbQuality_Scroll(object sender, EventArgs e)
        {
            lbQualityPreset.Text = trbQuality.Value.ToString();
            spCodecParams.Text = extLame.GetCodecParams(chCBR.Checked ? trbQuality.Value : trbQuality.Value + 100);
        }

        private void chDeleteOrigin_CheckedChanged(object sender, EventArgs e)
        {
            msbDeleteOrigin = false;
        }

        private void btChangeDir_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                tbDirectory.Text = folderBrowser.SelectedPath;
            }
        }

        private void tbExcludePattern_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lbExcludePatterns.Items.Add(tbExcludePattern.Text);
                tbExcludePattern.Clear();
            }
        }

        private void lbExcludePatterns_DoubleClick(object sender, EventArgs e)
        {
            lbExcludePatterns.Items.RemoveAt(lbExcludePatterns.SelectedIndex);
        }

        private void lbExcludePatterns_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lbExcludePatterns.SelectedIndex >= 0)
            {
                tbExcludePattern.Text = lbExcludePatterns.Items[lbExcludePatterns.SelectedIndex].ToString();
                lbExcludePatterns.Items.RemoveAt(lbExcludePatterns.SelectedIndex);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (extLame != null)
            {
                int c = extLame.GetPoolCapacity();
                spProgress.Text = Convert.ToString(c);

                if (c <= 0)
                {
                    timer1.Enabled = false;
                    InterfaceSetEnable(true);

                    if (chShutdownWhenDone.Checked)
                    {
                        if (cbScript.SelectedIndex > 0)
                        {
                            var scriptText = new List<string>();
                            scriptText.Add("");
                            scriptText.Add("shutdown -s -t 300");
                            File.AppendAllLines("BatchScript.bat", scriptText, Encoding.GetEncoding(866));
                        }

                        if ((ScriptMode)cbScript.SelectedIndex != ScriptMode.ScriptOnly)
                            Process.Start("shutdown", "-s -t 300");
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            if (extLame.GetPoolCapacity() > 0)
            {
                e.Cancel = true;
                if (MessageBox.Show("Все задания ещё не окончены.", "Хотите закрыть?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
            }
        }
    }
}
