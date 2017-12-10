using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class FishingArea7 : EncounterArea
    {
        public override int[] Species { get; set; } = new int[2];
        public byte NPC;

        public byte LevelMin = 10;
        public byte LevelMax;
        public virtual byte LevelMax2 => LevelMax;

        public byte SlottType;
        public byte SlottType2 => (byte)(SlottType + 1);

        public override int[] getSpecies(int ver, bool IsNight) => (int[])Species.Clone();
    }

    public class FishingArea_USUM : FishingArea7
    {
        public override byte LevelMax2 => (byte)(LevelMax + 5);
    }
}