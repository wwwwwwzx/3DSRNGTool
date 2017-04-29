using pkm3dsRNG.Core;

namespace pkm3dsRNG
{
    public class Result7 : RNGResult
    {
        public byte Blink;
        public ulong RandNum;
        public byte Clock;
        public int frameshift;

        public int realtime;
    }
}
