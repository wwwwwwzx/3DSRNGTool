namespace Pk3DSRNGTool
{
    public class Frame_Misc
    {
        public static bool X64;
        private static readonly string[] blinkmarks = { "-", "★", "?", "? ★" };

        public int Frame { get; set; }
        public uint Rand32 { get; set; }
        public ulong Rand64 { get; set; }
        public int RandN { get; set; }
        public byte Pokerus { get; set; }

        public byte Blink;
        public string BlinkFlag => Blink < 5 ? blinkmarks[Blink] : Blink.ToString();
        public byte Clock => (byte)(Rand64 % 17);
        public int realtime = -1;
        public string Realtime => realtime > -1 ? FuncUtil.Convert2timestr(realtime / 60.0) : string.Empty;
        public string CurrentSeed => X64 ? Rand64.ToString("X16") : Rand32.ToString("X8");
    }

    public class Misc_Filter
    {
        public bool Pokerus;
        public bool Random;
        public byte CompareType;
        public int Value;
        public string CurrentSeed;

        public bool check(Frame_Misc f)
        {
            if (Pokerus && f.Pokerus == 0)
                return false;
            if (CurrentSeed != null && !System.Text.RegularExpressions.Regex.IsMatch(f.CurrentSeed, CurrentSeed))
                return false;
            if (Random)
            {
                switch(CompareType)
                {
                    case 0: if (f.RandN >= Value) return false; break;
                    case 1: if (f.RandN < Value) return false; break;
                    case 2: if (f.RandN != Value) return false; break;
                }
            }
            return true;
        }
    }
}
