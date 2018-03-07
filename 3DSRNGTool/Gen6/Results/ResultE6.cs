using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class ResultE6 : EggResult
    {
        public object Status;

        public ResultE6(uint[] key)
        {
            RandNum = RNGPool.getcurrent;
            Status = RNGPool.getcurrentstate;
            EggSeed = key[0] | ((ulong)key[1] << 32);
        }
    }
}
