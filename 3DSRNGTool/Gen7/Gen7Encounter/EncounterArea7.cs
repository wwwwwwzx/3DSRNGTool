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
        public bool Raining;

        public override int[] getSpecies(int ver, bool IsNight) => getSpecies(ver == 6 || ver == 8, IsNight);

        protected virtual Dictionary<int, int> Day2Night { get; }
        protected virtual Dictionary<int, int> Sun2Moon { get; }

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
            new byte[]{1,2,3,4,5,5,6,7,7,8}, //37
            new byte[]{1,2,3,3,4,5,6,7,1,1}, //38
            new byte[]{1,2,3,3,4,4,5,6,6,7}, //39
            new byte[]{1,2,3,2,4,4,4,5,4,4}, //40
            new byte[]{1,2,3,4,5,6,7,6,8,8}, //41
            new byte[]{1,2,3,3,4,4,5,6,7,7}, //42
            new byte[]{1,2,3,4,3,4,5,6,6,7}, //43
            new byte[]{1,2,3,4,5,6,7,8,9,10}, //44 oops
            new byte[]{1,2,1,2,3,4,5,5,6,6}, //45
            new byte[]{1,2,3,4,5,5,6,6,7,7}, //46
        };
    }

    public class EncounterArea_SM : EncounterArea7
    {
        protected override Dictionary<int, int> Day2Night => new Dictionary<int, int>
        {
            {734, 019}, {735, 020},  // Yungoos -> Rattata
            {165, 167}, {166, 168},  // Ledyba -> Spinarak
            {046, 755},              // Paras -> Morelull
            {751, 283}, {752, 284},  // Dewplder -> Surskit
            {425, 200},              // Drifloon -> Misdreavus
            {745,2793},              // Lycanroc(day -> night)
            {174, 731},              // Igglybuff -> Pikipek
            // Reverse from here
            {173, 022},              // Cleff -> Fearow
        };

        protected override Dictionary<int, int> Sun2Moon => new Dictionary<int, int>
        {
            {546, 548}, // Cottonee -> Petill
            {766, 765}, // Passimian -> Oranguru
            {776, 324}, // Turtonator -> Torkoal
            {037, 027}, // Vulpix -> Sandshrew
            // Reverse from here
            {780, 359}, // Drampa -> Absol
        };
    }

    public class EncounterArea_USUM : EncounterArea7
    {
        protected override Dictionary<int, int> Day2Night => new Dictionary<int, int>
        {
            {734, 019}, {735, 020}, // Yungoos -> Rattata
            {165, 167}, {166, 168}, // Ledyba -> Spinarak
            {046, 755},             // Paras -> Morelull
            {751, 283}, {752, 284}, // Dewplder -> Surskit
            {425, 198},             // Drifloon -> Murkrow
            {745,2793},             // Lycanroc(day -> night)
            {296, 096}, {096, 296}, // Drowzee <-> Makuhita
            {447, 427},             // Riolu -> Buneary
        };

        protected override Dictionary<int, int> Sun2Moon => new Dictionary<int, int>
        {
            {546, 548}, // Cottonee -> Petill
            {766, 765}, // Passimian -> Oranguru
            {776, 324}, // Turtonator -> Torkoal
            {037, 027}, // Vulpix -> Sandshrew
            // Reverse from here
            {780, 359}, // Drampa -> Absol
        };
        
        protected override int[] getSpecies(bool IsMoon, bool IsNight)
        {
            var table = base.getSpecies(IsMoon, IsNight);
            IsNight ^= Reverse;
            IsMoon ^= Reverse;
            for (int i = 1; i < table.Length; i++)
                if (IsNight)
                {
                    if (table[i] == 173) // Cleff -> Minior/Elgyem
                        table[i] = i == 7 ? 774 : 605;
                    if (table[i] == 174) // Igglybuff -> Pikipek/Lillpup
                        table[i] = i == 7 ? 731 : 506;
                }
            return table;
        }
    }
}