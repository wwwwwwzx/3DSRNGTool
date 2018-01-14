using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class BTTrainer
    {
        // Result
        public byte TrainerID;
        // public int[] Pokemon;
        public override string ToString() =>  192 <= TrainerID && TrainerID <= 205 ? StringItem.TrainerName[TrainerID - 192] : TrainerID.ToString();

        // Setting
        private static int WinCount;
        public static int Steak
        {
            get => WinCount;
            set
            {
                WinCount = value;
                Special = WinCount % 10 == 0;
                if (WinCount <= 10)
                {
                    size = 50; offset = 0;
                    return;
                }
                if (WinCount <= 50)
                {
                    size = 40; offset = (byte)((WinCount - 1) / 10 * 20 + 10);
                    return;
                }
                size = 100; offset = 90; // > 50
            }
        }
        private static int Ver;
        public static int GameVer { get => Ver; set { Ver = value; N = Ver > 1 ? 114u : 100u; } }

        // Filter
        public bool IsDifferentFrom(BTTrainer result)
        {
            if (TrainerID < 209 && TrainerID != result.TrainerID)
                return true;
            return false;
        }

        // RNG
        private static ulong getrand => RNGPool.getrand64;
        private static bool Special;
        public static BTTrainer Generate()
        {
            return new BTTrainer
            {
                TrainerID = Special ? getSpecialTrainer() : getNormalTrainer(),
            };
        }

        // Special
        private static readonly byte[][] TrainerList =
        {
            new byte[] {197,201,199,192,194,195,196,193},
            new byte[] {198,202,200,192,194,195,196,193},
            new byte[] {197,201,199,192,194,195,196,205,193},
            new byte[] {198,202,200,192,194,195,196,205,193},
        };
        private static uint N;
        private static byte getSpecialTrainer()
        {
            int rand = (int)(getrand % N);
            int i = 0;
            while ((rand -= 14) >= 0)
                i++;
            return TrainerList[Ver][i];
        }

        // Normal
        private static byte size;
        private static byte offset;
        private static byte getNormalTrainer()
        {
            return (byte)(offset + getrand % size);
        }
    }
}
