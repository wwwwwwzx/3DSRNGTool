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
            Slot = Core.WildRNG.getSlot(Rand(rng, 100), 3);
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
        public string ItemString => string.Join(",", HeldItems.Select(t => StringItem.helditemStr[Wild6.getItem(t)]));

        public override string ToString()
        {
            string o = "Sync: " + FuncUtil.Bool2Str(Sync);
            o += "   Encounter Slot: " + Slot.ToString();
            o += "   HA Position: " + (HA == 0 ? StringItem.NONE_STR[StringItem.language] : HA.ToString());
            return o;
        }

        private static int Rand(TinyMT rng, ulong n) => (int)((rng.Nextuint() * n) >> 32);
    }
}
