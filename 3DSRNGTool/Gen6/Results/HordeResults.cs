using System.Linq;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public class HordeResults
    {
        public static bool IsXY => Program.mainform.Ver < 2;

        public HordeResults(TinyMT rng, int PKMNUM)
        {
            for (int i = 3 * PKMNUM + (IsXY ? 27 : 15); i > 0; i--)
                rng.Next();
            Sync = rng.Nextuint() < 0x80000000;
            Slot = HordeSlot(Rand(rng, 100));
            if (Rand(rng, 100) < 20) // 78de5c
                HA = (byte)(Rand(rng, 5) + 1); // 78de70
            for (int i = IsXY ? 1 : 6; i > 0; i--)
                rng.Next();
            for (int i = 0; i < 5; i++)
                HeldItems[i] = (byte)Rand(rng, 100);
        }

        public bool Sync;
        public byte Slot;
        public byte HA; // 0 for no HA, 1-5 means HA Slot
        public byte[] HeldItems = new byte[5];
        public string ItemString => string.Join(",", HeldItems.Select(t => Wild6.getitemstr(t)));

        public override string ToString()
        {
            string o = "Sync: " + FuncUtil.Bool2Str(Sync) + "  ";
            o += "Encounter Slot: " + Slot.ToString() + "  ";
            o += "Hidden Power Positon: " + (HA == 0 ? "None" : HA.ToString()) + "\n";
            return o;
        }

        private static byte HordeSlot(uint rand)
        {
            if (rand < 60)
                return 1;
            if (rand < 95)
                return 2;
            return 3;
        }

        private static uint Rand(TinyMT rng, ulong n) => (uint)((rng.Nextuint() * n) >> 32);
    }
}
