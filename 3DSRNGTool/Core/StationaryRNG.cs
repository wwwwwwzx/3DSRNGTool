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
        public bool ShinyCharm;

        public byte Level;
        public byte Gender;
        public bool RandomGender;
        public byte Ability;
        public int[] IVs;

        // Generated Attributes
        internal virtual int PerfectIVCount => IV3 ? 3 : 0;
        internal virtual int PIDroll_count => ShinyCharm && !IsShinyLocked && !AlwaysSync ? 3 : 1;

        public abstract RNGResult Generate();

        public virtual void UseTemplate(Pokemon PM)
        {
            AlwaysSync = PM.AlwaysSync;
            IV3 = PM.IV3;
            IsShinyLocked = PM.ShinyLocked;
            Ability = (byte)((PM.Ability >> 1) + 1);
            IVs = PM.IVs;
            Level = PM.Level;
            Gender = PM.SettingGender;
            RandomGender = PM.IsRandomGender;
            if (PM.Nature < 25)
                Synchro_Stat = PM.Nature;
        }
    }
}
