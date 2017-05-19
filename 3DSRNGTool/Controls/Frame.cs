using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    internal class Frame
    {
        public RNGResult rt;
        private int realtime;
        public bool Formatted;

        public Frame(RNGResult sc, int frame = -1, int time = -1, int eggnum = -1)
        {
            rt = sc;
            FrameNum = frame;
            realtime = time;
            EggNum = eggnum;
        }

        // DataSource Display Block
        private static readonly string[] blinkmarks = { "-", "★", "?", "? ★" };
        public static string[] Parents = { "-", "Male", "Female" };

        public static bool showstats;
        public static int standard;

        public int EggNum { get; private set; }
        public int FrameNum { get; private set; }
        public int Shift => realtime > -1 ? realtime - standard : 0;
        public string Mark
        {
            get
            {
                byte blink = (rt as Result7)?.Blink ?? 0;
                return blink < 4 ? blinkmarks[blink] : blink.ToString();
            }
        }
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
        public string Slot => (rt as WildResult)?.IsSpecial ?? false ? StringItem.gen7wildtypestr[1] : (rt as WildResult)?.Slot.ToString(); //todo
        public byte Level => rt.Level;
        public string Ball => Parents[(rt as EggResult)?.Ball ?? (rt as MainRNGEgg)?.Ball ?? 0];
        public string Item => (rt as WildResult)?.ItemStr ?? "";
        public uint Rand => (rt as Result6)?.RandNum ?? (rt as EggResult)?.RandNum ?? 0;
        public ulong Rand64 => (rt as Result7)?.RandNum ?? (rt as EggResult)?.EggSeed ?? 0;
        public uint PID => rt.PID;
        public uint EC => rt.EC;
        public string Status => (rt as EggResult)?.Status ?? (rt as Result6)?.Status ?? "";
        public string RealTime => realtime > -1 ? FuncUtil.Convert2timestr(realtime / 60.0) : "";
    }
}
