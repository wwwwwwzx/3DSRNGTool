using Pk3DSRNGTool.Core;
using System.Linq;
using System.Collections.Generic;

namespace Pk3DSRNGTool
{
    public class MiscEncounter7 : EncounterArea
    {
        public override int[] Species { get; set; }
        public byte NPC, DelayType1 = 1, DelayType2 = 1;
        public int Delay1 = 4, Delay2 = 90;
        public byte SlotType;

        public byte LevelMin;
        private byte _LevelMax;
        public byte LevelMax { get { return _LevelMax > 0 ? _LevelMax : (byte)(LevelMin + 3); } set { _LevelMax = value; } }

        public override bool DayNightDifference => Species.Any(i => Day2Night.ContainsKey(i) || UltraDay2Night.ContainsKey(i));
        private Dictionary<int, int> Day2Night => new Dictionary<int, int>
        {
            {734, 019}, {735, 020}, // Yungoos -> Rattata
        };
        private Dictionary<int, int> UltraDay2Night => new Dictionary<int, int>
        {
            {296, 096}, {096, 296}, // Drowzee <-> Makuhita
        };
        private Dictionary<int, int> Sun2Moon => new Dictionary<int, int>
        {
            {546, 548}, // Cottonee -> Petill
            {766, 765}, // Passimian -> Oranguru
            {627, 629}, {628, 630}, // Rufflet -> Vullaby
            {693, 691}, // Clawitzer -> Dragalge
        };
        public override int[] getSpecies(int ver, bool IsNight)
        {
            bool IsMoon = ver == 6 || ver == 8;
            bool IsUltra = ver > 6;
            int[] table = (int[])Species.Clone();
            for (int i = 0; i < table.Length; i++)
            {
                if (IsNight)
                    table[i] = Day2Night.TryGetValue(table[i], out int specform) ? specform : table[i];
                if (IsNight && IsUltra)
                    table[i] = UltraDay2Night.TryGetValue(table[i], out int specform) ? specform : table[i];
                if (IsMoon)
                    table[i] = Sun2Moon.TryGetValue(table[i], out int specform) ? specform : table[i];
                if (Pokemon.AlolanForms.Contains(table[i]))
                    table[i] += 2048;
            }
            return table;
        }
    }
}
