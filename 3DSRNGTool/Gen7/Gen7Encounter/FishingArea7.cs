using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class FishingArea7 : EncounterArea
    {
        public override int[] Species { get; set; } = new int[2];
        public byte NPC;

        public byte LevelMin = 10;
        public byte LevelMax;

        public byte SlotType;
        public byte SlotType2 => (byte)(SlotType + 1);

        public override int[] getSpecies(int ver, bool IsNight) => (int[])Species.Clone();
    }
}