using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class Result6 : RNGResult
    {
        public override GameVersion Version { get; protected set; } = GameVersion.Gen6;
        public uint RandNum;
        public PRNGState Status;
        public byte FrameUsed;

        public Result6()
        {
            RandNum = RNGPool.getcurrent;
            Status = RNGPool.getcurrentstate;
        }
    }
}