namespace PKHeX.Core
{
    public abstract class PersonalInfo
    {
        protected byte[] Data;
        public abstract int HP { get; }
        public abstract int ATK { get; }
        public abstract int DEF { get; }
        public abstract int SPE { get; }
        public abstract int SPA { get; }
        public abstract int SPD { get; }

        public int[] Stats => new[] { HP, ATK, DEF, SPE, SPA, SPD };

        public abstract int[] Types { get; }
        public abstract int CatchRate { get; }
        public abstract int[] Items { get; }
        public abstract int Gender { get; }
        public abstract int[] EggGroups { get; }
        public abstract int[] Abilities { get; }
        public abstract byte EscapeRate { get; }
        public virtual int FormeCount { get; }
        protected internal virtual int FormStatsIndex { get; }

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
