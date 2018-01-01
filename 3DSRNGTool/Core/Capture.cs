using System;

namespace Pk3DSRNGTool.Core
{
    public class CaptureResult
    {
        public byte CriticalVal;
        public ushort MaxRandom;
        public byte Shake;
        public byte Total;

        public bool Gotta => Shake == Total;
        public string Result_raw => CriticalVal.ToString("X2") + "/" + MaxRandom.ToString("X4");
        public string Result => Shake.ToString() + "/" + Total.ToString();
    }

    public abstract class Capture
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

        public abstract CaptureResult Catch();
    }

    public class Capture6 : Capture
    {
        public override CaptureResult Catch()
        {
            var output = new CaptureResult();
            output.CriticalVal = (byte)(getrand >> 24);
            output.Total = (byte)(output.CriticalVal < CriticalRate ? 1 : 4);
            if (AlwaysCapture)
                output.Shake = output.Total;
            else
            {
                for (byte i = 1; i <= output.Total; i++)
                {
                    ushort high16bits = (ushort)(getrand >> 16);
                    if (high16bits > output.MaxRandom)
                        output.MaxRandom = high16bits;
                    if (high16bits < ShakeRate && output.Shake == i - 1)
                        output.Shake = i;
                }
            }
            return output;
        }
    }

    public class Capture7 : Capture
    {
        public override CaptureResult Catch()
        {
            var output = new CaptureResult();
            output.CriticalVal = (byte)getrand;
            output.Total = (byte)(output.CriticalVal < CriticalRate ? 1 : 4);
            if (AlwaysCapture)
                output.Shake = output.Total;
            else
            {
                for (byte i = 1; i <= output.Total; i++)
                {
                    ushort low16bits = (ushort)getrand;
                    if (low16bits > output.MaxRandom)
                        output.MaxRandom = low16bits;
                    if (low16bits < ShakeRate && output.Shake == i - 1)
                        output.Shake = i;
                }
            }
            return output;
        }
    }
}
