namespace Pk3DSRNGTool
{
    public abstract class IPKM
    {
        public virtual GameVersion Version { get; protected set; } = GameVersion.Any;
        public short Species { get; set; }
        public byte Forme { get; set; }

        public virtual byte Ability { get; set; }
        public virtual byte Nature { get; set; }
        public virtual byte Gender { get; set; }

        public int[] IVs { get; set; }
        public byte Level { get; set; }

        public PKHeX.Core.PersonalInfo info => (GameVersion.Gen6.Contains(Version) ? PersonalTable.ORAS : PersonalTable.SM).getFormeEntry(Species, Forme);
        public bool IV3 => info.EggGroups[0] == 0xF;
    }
}
