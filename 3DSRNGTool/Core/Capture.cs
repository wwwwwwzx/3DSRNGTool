using System;

namespace Pk3DSRNGTool.Core
{
    public class CaptureResult
    {
        public static bool Details = true;
        public byte CriticalVal;
        public ushort MaxRandom;
        public byte Shake;
        public byte Total;

        public bool Gotta => Shake == Total;
        private string result_raw => CriticalVal.ToString("X2") + "/" + MaxRandom.ToString("X4");
        private string result_shake => Shake.ToString() + "/" + Total.ToString();
        public string Result => Details ? result_raw : result_shake;
    }

    public abstract class Capture
    {
        protected static uint getrand => RNGPool.getrand;

        public uint HPMax;
        public uint HPCurr;
        public byte CatchRate;
        public uint DexBonus;
        public uint StatusBonus;
        public uint BallBonus;

        public bool AlwaysCapture;
        public byte CriticalRate;
        public ushort ShakeRate = ushort.MaxValue;

        // To 1/4096
        private static ulong Multiply(ulong A, uint B) => (A * B + 0x800) >> 12;
        private static double Round(double A) => Math.Round(A * 4096) / 4096;

        public void Calc()
        {
            ulong HPFactor = ((3 * HPMax - 2 * HPCurr) << 12) * CatchRate;
            ulong AfterBall = Multiply(HPFactor, BallBonus) / (3 * HPMax);
            ulong A = StatusBonus == 0x1000 ? AfterBall : Multiply(AfterBall, StatusBonus);
            if (AlwaysCapture = A >= 0xFF000) A = 0xFF000;
            CriticalRate = (byte)Math.Round((Multiply(A, DexBonus) / 4096.0 / 6.0));
            if (A < 0xFF000)
                ShakeRate = (ushort)(A == 0 ? 0 : Math.Floor(65536.0 / Round(Math.Pow(Round(255 / (A / 4096.0)), 3.0 / 16))));
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
