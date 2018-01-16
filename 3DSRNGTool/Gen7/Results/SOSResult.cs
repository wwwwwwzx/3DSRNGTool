using System.Linq;

namespace Pk3DSRNGTool
{
    public class SOSResult
    {
        public byte Call1;
        public byte Call2;
        public bool Sync;
        public byte Slot;
        public byte Level;
        public byte HeldItem;
        public bool[] BumpedIVs;
        public bool HA;

        public bool Success => Call1 < SOSRNG.Rate1 && Call2 < SOSRNG.Rate2;

        public override string ToString() => string.Join(" / ", new string[]
        {
            Call1.ToString("D2"),
            Call2.ToString("D2"),
            Sync ? "O" : "X",
            Slot > 7 ? "W" + (Slot - 7).ToString() : Slot.ToString(),
            Level.ToString(),
            Wild7.getitemstr(HeldItem),
            string.Join(string.Empty, BumpedIVs.Select(iv => iv ? "V" : "X")),
            HA ? "HA" : "NA",
        });
    }
}
