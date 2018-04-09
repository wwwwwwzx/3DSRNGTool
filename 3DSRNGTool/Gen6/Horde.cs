using System.Linq;
using Pk3DSRNGTool.RNG;
using static Pk3DSRNGTool.Core.WildRNG;

namespace Pk3DSRNGTool
{
    public class Horde
    {
        // Result
        public byte Lead;
        public bool Sync => Lead < 50;
        public byte Slot;
        public byte HA; // 0 for no HA, 1-5 means HA Slot
        public byte[] FluteBoosts = new byte[5];
        public byte[] HeldItems = new byte[5];
        public string ItemString => string.Join(",", HeldItems.Select(t => StringItem.helditemStr[Wild6.getHeldItem(t)]));
        public string FluteString => FluteBoosts[0] == 0 ? null : string.Join(",", FluteBoosts.Select(f => f.ToString()));
        public override string ToString()
            => "Sync: " + FuncUtil.Bool2Str(Sync)
             + "   Encounter Slot: " + Slot.ToString()
             + "   HA Position: " + (HA == 0 ? StringItem.NONE_STR[StringItem.language] : HA.ToString());

        // RNG
        private static TinyMT rng;
        private static byte Rand(ulong n) => (byte)((rng.Nextuint() * n) >> 32);
        public Horde(uint[] src, int PKMNUM, bool IsORAS)
        {
            rng = new TinyMT(src);

            for (int i = 3 * PKMNUM + (IsORAS ? 15 : 27); i > 0; i--)
                rng.Next();

            Lead = Rand(100);
            Slot = getSlot(Rand(100), 3);
            if (Rand(100) < 20) // 78de5c
                HA = (byte)(Rand(5) + 1); // 78de70
            if (IsORAS) // 78df18
                for (int i = 0; i < 5; i++)
                    FluteBoosts[i] = getFluteBoost(Rand(100));
            rng.Next();
            for (int i = 0; i < 5; i++)
                HeldItems[i] = Rand(100);
        }
    }
}
