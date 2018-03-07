using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class ResultE6 : EggResult
    {
        public object Status;

        public ResultE6()
        {
            RandNum = RNGPool.getcurrent;
            Status = RNGPool.getcurrentstate;
        }
    }
}
