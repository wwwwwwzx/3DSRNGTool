using Pk3DSRNGTool.Core;
using System.Collections.Generic;
using System.Linq;

namespace Pk3DSRNGTool
{
    public class EncounterArea7 : EncounterArea
    {
        public override int[] Species { get; set; } = new int[1];
        public byte NPC, Correction = 1;

        public byte LevelMin;
        protected byte _LevelMax;
        public byte LevelMax { get { return _LevelMax > 0 ? _LevelMax : (byte)(LevelMin + 3); } set { _LevelMax = value; } }
        public short lvldiff; // Sun moon encounter area levels difference (Moon - Sun)
        public byte LevelMinMoon => (byte)(LevelMin + lvldiff);
        public byte LevelMaxMoon => (byte)(LevelMax + lvldiff);

        public bool Reverse; // true if moon/night have more species

        public override int[] getSpecies(int ver, bool IsNight) => getSpecies(ver == 6 || ver == 8, IsNight);

        protected virtual Dictionary<int, int> Day2Night => null;
        protected virtual Dictionary<int, int> Sun2Moon => null;

        public override bool VersionDifference => Species.Skip(1).Any(i => Sun2Moon.ContainsKey(i));
        public override bool DayNightDifference => Species.Skip(1).Any(i => Day2Night.ContainsKey(i));

        protected virtual int[] getSpecies(bool IsMoon, bool IsNight)
        {
            IsNight ^= Reverse;
            IsMoon ^= Reverse;
            int[] table = (int[])Species.Clone();
            for (int i = 1; i < table.Length; i++)
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

        public readonly static byte[][] SlotType = new byte[][]
        {
            new byte[]{1,2,1,2,3,3,4,4,4,4}, //0
            new byte[]{1,2,1,3,4,5,6,6,7,7}, //1
            new byte[]{1,2,1,3,4,5,6,7,3,3}, //2
            new byte[]{1,2,1,3,4,3,5,6,6,7}, //3
            new byte[]{1,2,3,1,4,5,6,5,7,7}, //4
            new byte[]{1,2,1,2,3,3,4,5,5,6}, //5
            new byte[]{1,2,3,4,5,6,2,6,6,6}, //6
            new byte[]{1,2,1,3,4,5,6,7,7,7}, //7
            new byte[]{1,2,1,2,3,3,4,4,3,5}, //8
            new byte[]{1,2,3,4,5,6,6,7,8,8}, //9
            new byte[]{1,2,3,3,3,3,4,5,6,6}, //10
            new byte[]{1,2,1,3,3,3,4,5,6,6}, //11
            new byte[]{1,2,3,4,5,5,6,6,6,6}, //12
            new byte[]{1,2,3,1,2,3,4,4,4,4}, //13
            new byte[]{1,2,1,3,4,4,5,5,5,5}, //14
            new byte[]{1,1,2,2,3,3,3,3,3,3}, //15
            new byte[]{1,2,3,2,4,4,5,5,5,5}, //16
            new byte[]{1,2,3,4,5,4,4,4,4,4}, //17
            new byte[]{1,2,3,4,5,5,2,2,2,2}, //18
            new byte[]{1,2,3,2,4,4,2,2,2,5}, //19
            new byte[]{1,2,3,3,4,5,6,3,7,7}, //20
            new byte[]{1,2,1,2,3,4,5,6,6,6}, //21
            new byte[]{1,2,1,2,3,4,5,5,5,5}, //22
            new byte[]{1,2,1,3,4,5,6,5,7,7}, //23
            new byte[]{1,2,1,1,2,2,2,3,4,4}, //24
            new byte[]{1,2,3,3,4,4,3,4,4,4}, //25
            new byte[]{1,2,3,3,1,2,4,4,4,4}, //26
            new byte[]{1,2,1,2,3,3,4,4,5,5}, //27
            new byte[]{1,2,1,2,1,2,3,3,4,4}, //28
            new byte[]{1,2,3,2,3,3,4,3,3,3}, //29
            new byte[]{1,2,3,3,4,4,1,4,5,5}, //30
            new byte[]{1,2,3,4,5,6,7,5,5,5}, //31
            // USUM
            new byte[]{1,2,3,4,4,2,5,6,6,6}, //32
            new byte[]{1,2,3,4,4,5,6,5,7,7}, //33
            new byte[]{1,1,2,2,3,3,4,4,4,4}, //34
            new byte[]{1,2,3,4,5,6,7,8,8,8}, //35
            new byte[]{1,2,1,2,3,3,3,1,2,2}, //36
            new byte[]{1,2,3,4,3,3,5,6,6,7}, //37
            new byte[]{1,2,3,3,4,5,6,7,1,1}, //38
            new byte[]{1,2,3,3,4,4,5,6,6,7}, //39
            new byte[]{1,2,3,2,4,4,4,5,4,4}, //40
        };
    }

    public class EncounterArea_SM : EncounterArea7
    {
        protected override Dictionary<int, int> Day2Night => day2night;
        protected override Dictionary<int, int> Sun2Moon => sun2moon;
        private readonly static Dictionary<int, int> day2night = new Dictionary<int, int>
        {
            {734, 019}, {735, 020},
            {165, 167}, {166, 168},
            {046, 755},
            {751, 283}, {752, 284},
            {425, 200},
            {745,2793},
            {174, 731},
            // Reverse from here
            {173, 022},
        };

        private readonly static Dictionary<int, int> sun2moon = new Dictionary<int, int>
        {
            {546, 548},
            {766, 765},
            {776, 324},
            {037, 027},
            // Reverse from here
            {780, 359},
        };
    }

    public class EncounterArea_USUM : EncounterArea7
    {
        protected override Dictionary<int, int> Day2Night => day2night;
        protected override Dictionary<int, int> Sun2Moon => sun2moon;
        private readonly static Dictionary<int, int> day2night = new Dictionary<int, int>
        {
            {734, 019}, {735, 020},
            {165, 167}, {166, 168},
            {046, 755},
            {751, 283}, {752, 284},
            {425, 198},
            {745,2793},
            {174, 731},
            {296, 096}, {096, 296},
            {447, 427},
            // Reverse from here
            {173, 022},
        };

        private readonly static Dictionary<int, int> sun2moon = new Dictionary<int, int>
        {
            {546, 548},
            {766, 765},
            {776, 324},
            {037, 027},
            // Reverse from here
            {780, 359},
        };
    }
}
