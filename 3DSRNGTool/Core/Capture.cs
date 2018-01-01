using System;

namespace Pk3DSRNGTool.Core
{
    public class Capture
    {
        protected static uint getrand => RNGPool.getrand;
        private const ulong CritcalFactor = 0x2AAAAAABul; // 1/6

        public uint HPMax;
        public uint HPCurr;
        public byte CatchRate;
        public uint DexBonus;
        public uint StatusBonus;
        public uint BallBonus;

        public bool AlwaysCapture;
        public byte CriticalRate;
        public ushort ShakeRate = ushort.MaxValue;
        public uint[] outcome = new uint[3]; // 0: Actual Shake Number 1: Total Shake Number 2: Maxmimun RN

        private static uint Multiply(uint A, uint B) => (A * B + 0x800) >> 12;
        private static double ToDouble(uint A) => (A >> 12) + ((A & 0xFFF) > 0 ? (A & 0xFFF) * 0.000244140625 : 0.0);

        public void Calc()
        {
            uint HPFactor = (uint)(((3 * HPMax - 2 * HPCurr) << 12) + 0.5) * CatchRate;
            uint AfterBall = Multiply(HPFactor, BallBonus) / HPMax;
            uint A = StatusBonus == 0x1000 ? AfterBall : Multiply(AfterBall, StatusBonus);
            if (AlwaysCapture = A >= 0xFF000) A = 0xFF000;
            CriticalRate = (byte)((CritcalFactor * Multiply(A, DexBonus)) >> 34);
            ShakeRate = (ushort)(65536.0 / Math.Pow(255.0 / ToDouble(A), 0.75) - 0.5);
        }
    }

    public class Capture7 : Capture
    {
        public bool Catch()
        {
            outcome[1] = (byte)getrand < CriticalRate ? 1u : 4u;
            if (AlwaysCapture)
                outcome[0] = outcome[1];
            else
            {
                for (uint i = 1; i <= outcome[1]; i++)
                {
                    var low16bits = (ushort)getrand;
                    if (low16bits > outcome[2])
                        outcome[2] = low16bits;
                    if (low16bits < ShakeRate && outcome[0] == i - 1)
                        outcome[0] = i;
                }
            }
            return outcome[0] == outcome[1];
        }
    }
}
