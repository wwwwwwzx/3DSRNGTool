using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class FishingArea7 : EncounterArea
    {
        public override int[] Species { get; set; } = new int[2];
        public byte NPC;
        public bool Longdelay; // 89/97 vs 78
        public bool Lapras; // Increase pkm generation delay by 2

        public byte LevelMin = 10;
        public byte LevelMax;

        public byte SlotType; // Bubbling slottype++

        public override int[] getSpecies(int ver, bool IsNight) => (int[])Species.Clone();
    }
}