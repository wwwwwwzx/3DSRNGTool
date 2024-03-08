using System.Linq;

namespace Pk3DSRNGTool
{
    public class SOSResult
    {
        public static bool Details;
        public byte Call1;
        public byte Call2;
        public bool Sync;
        public byte Slot;
        public byte Level;
        public byte HeldItem;
        public bool[] BumpedIVs = new bool[6];
        public bool HA;
        public int Advance;

        public bool Success => Call1 < SOSRNG.Rate1 && Call2 < SOSRNG.Rate2;

        public override string ToString() => string.Join(" , ", new string[]
        {
            Details ? Call1.ToString("D2") + "/" + Call2.ToString("D2") : FuncUtil.Bool2Str(Call1 < SOSRNG.Rate1) + FuncUtil.Bool2Str(Call2 < SOSRNG.Rate2),
            FuncUtil.Bool2Str(Sync),
            Slot > 7 ? "W" + (Slot - 7).ToString() : Slot.ToString(),
            Level.ToString(),
            StringItem.helditemStr[Wild7.getHeldItem(HeldItem)],
            string.Join("/", BumpedIVs.Select(iv => iv ? "31" : "x")),
            HA ? "HA" : "---",
        });
    }
}
