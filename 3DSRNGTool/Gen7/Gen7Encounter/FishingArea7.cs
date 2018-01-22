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

        public byte[] getitemslots(bool IsUltraBubbling)
        {
            byte[] slots = new byte[2];
            int index = Island + (IsUltraBubbling ? 4 : 0);
            slots[0] = FishingItemSlots[index * 3];
            slots[1] = (byte)(FishingItemSlots[index * 3] + FishingItemSlots[index * 3 + 1]);
            return slots;
        }

        private byte Island
        {
            get
            {
                if (Location < 50)
                    return 0;
                if (Location < 106)
                    return 1;
                if (Location < 156)
                    return 2;
                return 3;
            }
        }

        private static byte[] FishingItemSlots = new byte[]
        {
            50,30,20,
            50,30,20,
            50,40,10,
            60,30,10,
            60,30,10, // Ultra Bubbling
            45,30,25,
            40,30,30,
            80,19,01,
        };

        public override int[] getSpecies(int ver, bool IsNight) => (int[])Species.Clone();
    }
}