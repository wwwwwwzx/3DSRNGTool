using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class Result7 : RNGResult
    {
        public override GameVersion Version { get; set; } = GameVersion.Gen7;
        public byte Blink;
        public ulong RandNum;
        public byte Clock;
        public int FrameDelayUsed;
    }
}
