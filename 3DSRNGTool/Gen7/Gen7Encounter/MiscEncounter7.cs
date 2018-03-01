using Pk3DSRNGTool.Core;
using System.Collections.Generic;

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

        private Dictionary<int, int> Day2Night => new Dictionary<int, int>
        {
            {734, 019}, {735, 020}, // Yungoos -> Rattata
            {296, 096}, {096, 296}, // Drowzee <-> Makuhita
        };
        private Dictionary<int, int> Sun2Moon => new Dictionary<int, int>
        {
            {546, 548}, // Cottonee -> Petill
        };
        public override int[] getSpecies(int ver, bool IsNight)
        {
            bool IsMoon = ver == 6 || ver == 8;
            int[] table = (int[])Species.Clone();
            for (int i = 0; i < table.Length; i++)
            {
                if (IsNight)
                    table[i] = Day2Night.TryGetValue(table[i], out int specform) ? specform : table[i];
                if (IsMoon)
                    table[i] = Sun2Moon.TryGetValue(table[i], out int specform) ? specform : table[i];
                if (Pokemon.AlolanForms.Contains(table[i]))
                    table[i] += 2048;
            }
            return table;
        }
    }
}
