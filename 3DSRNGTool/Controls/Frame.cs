using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    internal class Frame
    {
        public RNGResult rt;
        private int realtime;
        public bool Formatted;

        public Frame(RNGResult sc, int frame = -1, int time = -1, int eggnum = -1, byte blink = 0)
        {
            rt = sc;
            FrameNum = frame;
            realtime = time;
            EggNum = eggnum;
            Blink = blink;
        }

        // DataSource Display Block
        private static readonly string[] blinkmarks = { "-", "★", "?", "? ★" };
        public static string[] Parents = { "-", "Male", "Female" };
        public static string SpecialSlotStr;

        public static bool showstats;
        public static int standard;

        public int EggNum { get; private set; }
        public int FrameNum { get; private set; }
        public int Shift => realtime > -1 ? realtime - standard : 0;
        public byte Blink;
        public string Mark => Blink < 4 ? blinkmarks[Blink] : Blink.ToString();
        private string _FrameUsed;
        public string FrameUsed { get => _FrameUsed ?? (rt as EggResult)?.FramesUsed.ToString("+#") ?? (rt as Result6)?.FrameUsed.ToString("+00") ?? ""; set => _FrameUsed = value; }
        public int HP => showstats ? rt.Stats[0] : rt.IVs[0];
        public int Atk => showstats ? rt.Stats[1] : rt.IVs[1];
        public int Def => showstats ? rt.Stats[2] : rt.IVs[2];
        public int SpA => showstats ? rt.Stats[3] : rt.IVs[3];
        public int SpD => showstats ? rt.Stats[4] : rt.IVs[4];
        public int Spe => showstats ? rt.Stats[5] : rt.IVs[5];
        public string NatureStr
        {
            get
            {
                if (null != ((rt as EggResult)?.BE_InheritParents))
                    return Parents[((rt as EggResult).BE_InheritParents == true) ? 1 : 2];
                return StringItem.naturestr[rt.Nature];
            }
        }
        public char Sync => rt.Synchronize ? 'O' : 'X';
        public string HiddenPower => StringItem.hpstr[rt.hiddenpower + 1];
        public uint PSV => rt.PSV;
        public string GenderStr => StringItem.genderstr[rt.Gender];
        public string AbilityStr => StringItem.abilitystr[rt.Ability];
        public int Delay => (rt as Result7)?.FrameDelayUsed ?? 0;
        public string Slot => (rt as WildResult)?.IsSpecial ?? false ? SpecialSlotStr : (rt as WildResult)?.Slot.ToString();
        public byte Level => rt.Level;
        public string Ball => Parents[(rt as EggResult)?.Ball ?? (rt as ResultME7)?.Ball ?? 0];
        public string Item => (rt as WildResult)?.ItemStr ?? "";
        public uint Rand => (rt as Result6)?.RandNum ?? (rt as EggResult)?.RandNum ?? 0;
        public ulong Rand64 => (rt as Result7)?.RandNum ?? (rt as EggResult)?.EggSeed ?? 0;
        public uint PID => rt.PID;
        public uint EC => rt.EC;
        public string WurmpleEvo => (rt.EC >> 16) % 10 < 5 ? StringItem.species[267] : StringItem.species[269];
        public string State => (rt as Result6)?.Status.ToString() ?? (rt as ResultE6)?.Status.ToString() ?? "";
        public PRNGState _tinystate;
        public string TinyState => (_tinystate ?? (rt as ResultE7)?.Status)?.ToString() ?? "";
        public string RealTime => realtime > -1 ? FuncUtil.Convert2timestr(realtime / 60.0) : "";
    }
}
