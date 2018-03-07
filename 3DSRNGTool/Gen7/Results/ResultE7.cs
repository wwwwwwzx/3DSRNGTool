using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class ResultE7 : EggResult
    {
        public PRNGState Status;

        public ResultE7()
        {
            RandNum = RNGPool.getcurrent;
            Status = RNGPool.getcurrentstate;
        }
    }
}
