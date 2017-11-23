namespace Pk3DSRNGTool.Core
{
    public abstract class StationaryRNG : IGenerator
    {
        // Background Info (Global variables)
        public bool AlwaysSync;
        public byte Synchro_Stat;
        public bool IV3;
        public int TSV;
        public bool IsShinyLocked;
        public bool IsForcedShiny;
        public bool ShinyCharm;

        public byte Level;
        public byte Gender;
        public bool RandomGender;
        public byte Ability;
        public int[] IVs;

        protected int PerfectIVCount;
        protected int PIDroll_count;
        public void SetValue()
        {
            PerfectIVCount = IV3 ? 3 : 0;
            PIDroll_count = ShinyCharm && !IsShinyLocked && !AlwaysSync ? 3 : 1;
        }

        public virtual void Delay() { }
        public abstract RNGResult Generate();

        public virtual void UseTemplate(Pokemon PM)
        {
            AlwaysSync = PM.AlwaysSync;
            IV3 = PM.IV3 && !PM.Egg;
            IsShinyLocked = PM.ShinyLocked;
            Ability = (byte)(PM.Ability > 3 ? 3 : PM.Ability); // Ability 0/1/2/4 => 0/1/2/3
            IVs = PM.IVs ?? new[] { -1, -1, -1, -1, -1, -1 };
            if (PM.Level > 0)
                Level = PM.Level;
            Gender = PM.SettingGender;
            RandomGender = PM.IsRandomGender;
            if (PM.Nature < 25)
                Synchro_Stat = PM.Nature;
            SetValue();
        }
    }
}
