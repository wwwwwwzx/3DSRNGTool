using System.Linq;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public class HordeResults
    {
        public static bool IsXY => Program.mainform.Ver < 2;
        public const uint HAThre = 30;

        public HordeResults(TinyMT rng, int PKMNUM)
        {
            for (int i = 3 * PKMNUM + (IsXY ? 27 : 15); i > 0; i--)
                rng.Next();
            Sync = rng.Nextuint() < 0x80000000;
            Slot = HordeSlot(Rand(rng, 100));
            if (Rand(rng, 100) < HAThre)
                HA = (byte)(Rand(rng, 5) + 1);
            for (int i = IsXY ? 1 : 6; i > 0; i--)
                rng.Next();
            for (int i = 0; i < 5; i++)
                HeldItems[i] = (byte)Rand(rng, 100);
        }

        public bool Sync;
        public byte Slot;
        public byte HA; // 0 for no HA, 1-5 means HA Slot
        public byte[] HeldItems = new byte[5];

        public override string ToString()
        {
            string o = "Sync: " + (Sync ? "O" : "X") + "  ";
            o += "Encounter Slot: " + Slot.ToString() + "  ";
            o += "HA Positon: " + (HA == 0 ? "None" : HA.ToString()) + "  ";
            o += "Held Item: " + ItemString;
            return o;
        }

        public string ItemString => string.Join(",", HeldItems.Select(t => ItemStr(t)));

        private static byte HordeSlot(uint rand)
        {
            if (rand < 60)
                return 1;
            if (rand < 95)
                return 2;
            return 3;
        }

        private static string ItemStr(uint rand)
        {
            if (rand < 50)
                return "50%";
            if (rand < 55)
                return "5%";
            if (rand < 56)
                return "1%";
            return "---";
        }

        private static uint Rand(TinyMT rng, ulong n) => (uint)((rng.Nextuint() * n) >> 32);
    }
}
