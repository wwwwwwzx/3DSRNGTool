namespace Pk3DSRNGTool
{
    public class DexNavResult
    {
        public byte Lead;
        public bool Sync => Lead < 50;
        public int LevelBoost;
        public byte FluteBoost;
        public bool HA;
        public byte Potential;
        public bool EggMove;
        public byte HeldItem;
        public bool ForcedShiny;
    }
}
