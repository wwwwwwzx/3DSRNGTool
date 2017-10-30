namespace Pk3DSRNGTool
{
    public abstract class IPKM
    {
        public virtual GameVersion Version { get; protected set; } = GameVersion.Any;
        public short Species;
        public byte Forme;

        public virtual byte Ability { get; set; }
        public virtual byte Nature { get; set; }
        public virtual byte Gender { get; set; }

        public int[] IVs;
        public byte Level;

        public PKHeX.Core.PersonalInfo info => (GameVersion.Gen6.Contains(Version) ? PersonalTable.ORAS : PersonalTable.USUM).getFormeEntry(Species, Forme);
    }
}
