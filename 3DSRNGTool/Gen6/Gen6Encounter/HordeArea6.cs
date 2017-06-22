using System;
using System.Linq;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public abstract class HordeArea : EncounterArea
    {
        public override int Locationidx => Location + (idx << 9);
        public override int[] Species { get; set; } = new int[3];
        public byte Level;
    }

    public class HordeArea_XY : HordeArea
    {
        private readonly static int[] XList = { 311, 312, 335, 336, 304, 228 };
        private readonly static int[] YList = { 312, 311, 336, 335, 246, 309 };
        private readonly static int[][] SpecialHorde =
        {
            // Main, Alt, Slot of 5, Slot of horde(3)
           new[] { 311, 312, 3, 2 },
           new[] { 335, 336, 1, 1 },
           new[] { 032, 029, 4, 0 },
           new[] { 128, 241, 1, 2 },
           new[] { 524, 703, 3, 2 },
           new[] { 709, 185, 3, 2 },
           new[] { 632, 631, 3, 2 },
        };
        private readonly static int[] Special = SpecialHorde.Select(t => t[0]).ToArray();

        public override bool VersionDifference => Species.Any(i => XList.Contains(i));
        public override int[] getSpecies(int ver, bool IsNight) => getSpecies(ver == 1);

        private int[] getSpecies(bool IsY)
        {
            int[] table = (int[])Species.Clone();
            if (IsY && VersionDifference)  // Replace ORAS species
            {
                for (int i = 0; i < 3; i++)
                {
                    int idx = Array.IndexOf(XList, table[i]);
                    if (idx > -1)
                        table[i] = YList[idx];
                }
            }
            return table;
        }
        public int[] getSpecies(bool IsY, byte Slot)
        {
            int[] table = new int[5];
            int species = Species[Slot - 1];
            for (int i = 0; i < 5; i++)
                table[i] = species;
            int idx = Array.IndexOf(Special, species);
            if (idx > -1 && SpecialHorde[idx][3] == Slot)
                table[SpecialHorde[idx][2]] = SpecialHorde[idx][1];
            if (IsY && VersionDifference)  // Replace XY species
                for (int i = 0; i < 5; i++)
                {
                    idx = Array.IndexOf(XList, table[i]);
                    if (idx > -1)
                        table[i] = YList[idx];
                }
            return table;
        }
    }

    public class HordeArea_ORAS : HordeArea
    {
        private readonly static int[] ORList = { 311, 312, 303, 109, 273 };
        private readonly static int[] ASList = { 312, 311, 302, 088, 270 };
        private readonly static int[][] SpecialHorde =
        {
            // Main, Alt, Slot of 5, Slot of horde(3), location
            new[] { 312, 311, 1, 2, 222},
            new[] { 043, 263, 4, 0, 236},
            new[] { 296, 074, 2, 1, 280},
            // Swablu in Lotad
        };
        private readonly static int[] Special = SpecialHorde.Select(t => t[0]).ToArray();

        public override bool VersionDifference => Species.Any(i => ORList.Contains(i));
        public override int[] getSpecies(int ver, bool IsNight) => getSpecies(ver == 3);

        private int[] getSpecies(bool IsAS)
        {
            int[] table = (int[])Species.Clone();
            if (IsAS && VersionDifference)  // Replace ORAS species
            {
                for (int i = 0; i < 3; i++)
                {
                    int idx = Array.IndexOf(ORList, table[i]);
                    if (idx > -1)
                        table[i] = ASList[idx];
                }
            }
            return table;
        }
        public int[] getSpecies(bool IsAS, byte Slot)
        {
            int[] table = new int[5];
            int species = Species[Slot - 1];
            for (int i = 0; i < 5; i++)
                table[i] = species;
            int idx = Array.IndexOf(Special, species);
            if (idx > -1 && SpecialHorde[idx][3] == Slot && SpecialHorde[idx][4] == Location)
                table[SpecialHorde[idx][2]] = SpecialHorde[idx][1];
            if (IsAS && VersionDifference)  // Replace ORAS species
            {
                for (int i = 0; i < 5; i++)
                {
                    idx = Array.IndexOf(ORList, table[i]);
                    if (idx > -1)
                        table[i] = ASList[idx];
                }
                if (Location == 230 && species == 270) //Route 114
                    table[3] = 333;
            }
            return table;
        }
    }
}