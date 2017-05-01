using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class Result6 : RNGResult
    {
        public override GameVersion Version { get; set; } = GameVersion.Gen6;
        public uint RandNum;
    }
}
