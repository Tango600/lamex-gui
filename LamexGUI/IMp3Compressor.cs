using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamexGUI
{
    public enum ScriptMode
    {
        None,
        Script,
        ScriptOnly
    }

    interface IMp3Compressor
    {
        void Compress(string wavFile, string outFile, int qualityPreset, bool deleteOrigin, ScriptMode scriptMode);
        string GetCodecParams(int qualityPreset);
        int GetPoolCapacity();
    }
}
