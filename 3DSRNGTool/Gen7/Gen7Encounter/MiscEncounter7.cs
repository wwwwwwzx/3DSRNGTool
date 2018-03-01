using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class MiscEncounter7 : EncounterArea
    {
        public override int[] Species { get; set; }
        public byte NPC, DelayType1, DelayType2;
        public int Delay1, Delay2;
        public byte SlotType;

        public byte LevelMin;
        private byte _LevelMax;
        public byte LevelMax { get { return _LevelMax > 0 ? _LevelMax : (byte)(LevelMin + 3); } set { _LevelMax = value; } }
        public override int[] getSpecies(int ver, bool IsNight) => (int[])Species.Clone();
    }
}
