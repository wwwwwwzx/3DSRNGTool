namespace PKHeX.Core
{
    public abstract class PersonalInfo
    {
        protected byte[] Data;
        public abstract byte[] Write();
        public abstract int HP { get; set; }
        public abstract int ATK { get; set; }
        public abstract int DEF { get; set; }
        public abstract int SPE { get; set; }
        public abstract int SPA { get; set; }
        public abstract int SPD { get; set; }

        public int[] Stats => new[] { HP, ATK, DEF, SPE, SPA, SPD };
        
        public abstract int CatchRate { get; set; }
        public abstract int[] Items { get; set; }
        public abstract int Gender { get; set; }
        public abstract int[] EggGroups { get; set; }
        public abstract int [] Abilities { get; set; }
        public virtual int FormeCount { get; set; }
        protected internal virtual int FormStatsIndex { get; set; }

        // Data Manipulation
        public int FormeIndex(int species, int forme)
        {
            if (forme <= 0) // no forme requested
                return species;
            if (FormStatsIndex <= 0) // no formes present
                return species;
            if (forme > FormeCount) // beyond range of species' formes
                return species;

            return FormStatsIndex + forme - 1;
        }
        public bool HasFormes => FormeCount > 1;
        public int BST => HP + ATK + DEF + SPE + SPA + SPD;
    }
}
