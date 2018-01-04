using System.Linq;
using Pk3DSRNGTool.Core;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public class FPFacility
    {
        public byte star;
        public sbyte type = -1;
        public sbyte NPC = -1;
        public sbyte Color = -1;

        public string Result => string.Format("{0} ★{1} - N{2} - C{3}", StringItem.FacilityName[type], star, NPC, Color);
        
        // Filter
        public bool IsDifferentFrom(FPFacility result)
        {
            if (star != 0 && star != result.star)
                return true;
            if (type >= 0 && type != result.type)
                return true;
            if (NPC >= 0 && NPC != result.NPC)
                return true;
            if (Color >= 0 && Color != result.Color)
                return true;
            return false;
        }

        // Generator setting
        public static byte Rank;
        public static byte GameVer { get => Ver; set { Ver = value; setlist(); } }
        private static byte Ver;
        private static bool IsMoon = Ver == 1 && Ver == 3;

        // RNG
        private static TinyMT tiny = new TinyMT(0);
        private static void Reseed() => tiny.Reseed((uint)RNGPool.getcurrent64);
        public static FPFacility Generate()
        {
            Reseed();

            var result = new FPFacility();

            result.star = getStar(tiny.Nextuint() % 100);

            result.type = FacilityList[result.star * 2 - (IsMoon ? 1 : 2)][tiny.Nextuint() % Nlist[result.star - 1]];

            result.NPC = (sbyte)(tiny.Nextuint() % 12);

            result.Color = getColor(tiny.Nextuint() % 100);
            
            return result;
        }

        // Data
        private readonly static byte[] StarChance =
        {
            100,0,0,0,0,    // <=2
            75,19,6,0,0,    // 3
            75,17,8,0,0,    // 4
            75,15,10,0,0,   // 5
            50,38,12,0,0,   // 6
            50,36,14,0,0,   // 7
            50,34,16,0,0,   // 8
            50,32,18,0,0,   // 9
            40,35,20,5,0,   // 10
            30,40,22,7,1,   // 11-20
            25,40,24,0,2,   // 21-30
            20,35,31,11,3,  // 31-40
            15,30,38,13,4,  // 41-50
            10,25,45,15,5,  // 51-60
            10,20,47,17,6,  // 61-70
            10,15,49,19,7,  // 71-80
            10,15,46,21,8,  // 81-90
            10,15,43,23,9,  // 91-99
            10,15,40,25,10, // 100+
        };
        private static byte getStar(uint R100)
        {
            int rand = (int)R100;
            for (byte i = 1; i < 5; i++)
            {
                rand -= StarChance[Rank * 5 + i - 1];
                if (rand < 0)
                    return i;
            }
            return 5;
        }
        private readonly static sbyte[][] FacilityList =
        {
            new sbyte[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,19,21,23,24,25,27,29,31,33},
            new sbyte[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,20,22,24,26,28,30,32,33},
            new sbyte[] {3,4,5,7,9,10,14,16,17,33},
            new sbyte[] {0,1,2,6,8,11,13,15,33},
            new sbyte[] {0,1,2,9,10,11,12,14,16,19,21,23,25,27,29,31,33},
            new sbyte[] {3,4,5,6,7,8,13,15,17,18,20,22,24,26,28,30,32,33},
            new sbyte[] {3,4,5,7,14,16,17},
            new sbyte[] {0,1,2,11,13,15},
            new sbyte[] {0,1,2,11,14,16,19,21,23,24,25,27,29,31},
            new sbyte[] {3,4,5,7,13,15,17,18,20,22,24,26,28,30,32},
        };
        public static int[] getList(byte ver, int star)
        {
            GameVer = ver;
            if (star < 1)
                star = 1;
            var tmp = FacilityList[2 *  star - (IsMoon ? 1 : 2)].ToList();
            if (star <= 3 && ver < 2)
                tmp.Remove(33); // Switcheroo
            return tmp.Select(i => (int)i).ToArray();
        }
        private static int[] Nlist = new int[5];
        private static void setlist()
        {
            for (int i = 0; i < 5; i++)
                Nlist[i] = FacilityList[2 * i + (IsMoon ? 1 : 0)].Count() - (Ver < 2 && i < 3 ? 1 : 0);
        }
        private static sbyte getColor(uint rand)
        {
            if (rand < 5)
                return 3;
            if (rand < 20)
                return 2;
            if (rand < 50)
                return 1;
            return 0;
        }
    }
}
