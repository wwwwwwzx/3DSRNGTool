using System;
using System.Linq;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public abstract class HordeArea : EncounterArea
    {
        public override int Locationidx => Location + (idx << 9);
        public override int[] Species { get; set; } = new int[3];
        protected byte Level;
    }

    public class HordeArea_XY : HordeArea
    {
        private readonly static int[] XList = { 311, 312, 335, 336 };
        private readonly static int[] YList = { 312, 311, 336, 335 };
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
                        table[i] = XList[idx];
                }
            return table;
        }

        public readonly HordeArea_XY[] Table =
        {
            new HordeArea_XY
            {
               Location = 028, // Route 5
               Species = new[] {316 ,559 ,311},
               Level = 5,
            },
            new HordeArea_XY
            {
               Location = 038, // Route 7
               Species = new[] {187 ,054 ,315},
               Level = 7,
            },
            new HordeArea_XY
            {
               Location = 042, // Route 8
               Species = new[] {278 ,335 ,276},
               Level = 7,
            },
            new HordeArea_XY
            {
               Location = 050, // Route 10
               Species = new[] {299 ,193 ,228},
               Level = 10,
            },
            new HordeArea_XY
            {
               Location = 054, // Route 11
               Species = new[] {032 ,434 ,396},
               Level = 11,
            },
            new HordeArea_XY
            {
               Location = 062, // Route 12
               Species = new[] {278 ,179 ,128},
               Level = 13,
            },
            new HordeArea_XY
            {
               Location = 068, // Route 14
               Species = new[] {069 ,451 ,023},
               Level = 16,
            },
            new HordeArea_XY
            {
               Location = 074, // Route 15
               Species = new[] {198 ,590 ,707},
               Level = 18,
            },
            new HordeArea_XY
            {
               Location = 078, // Route 16
               Species = new[] {198 ,590 ,707},
               Level = 18,
            },
            new HordeArea_XY
            {
               Location = 088, // Route 18
               Species = new[] {074 ,632 ,632},
               Level = 23,
            },
            new HordeArea_XY
            {
               Location = 092, // Route 19
               Species = new[] {070 ,207 ,024},
               Level = 24,
            },
            new HordeArea_XY
            {
               Location = 096, // Route 20
               Species = new[] {590 ,709 ,709},
               Level = 25,
            },
            new HordeArea_XY
            {
               Location = 100, // Route 21
               Species = new[] {327 ,333 ,123},
               Level = 26,
            },
            new HordeArea_XY
            {
               Location = 056, // Reflection Cave
               Species = new[] {439 ,524 ,524},
               Level = 11,
            },
            new HordeArea_XY
            {
               Location = 082, // Frost Cavern
               Species = new[] {582 ,613 ,238},
               Level = 20,
            },
            new HordeArea_XY
            {
               Location = 098, // Pokémon Village
               Species = new[] {590 ,060 ,271},
               Level = 25,
            },
            new HordeArea_XY
            {
               Location = 104, // Victory Road
               Species = new[] {074 ,419 ,108},
               Level = 28,
            },
            new HordeArea_XY
            {
               Location = 134, // Connecting Cave
               Species = new[] {293 ,041 ,610},
               Level = 7,
            },
            new HordeArea_XY
            {
               Location = 140, // Terminus Cave
               Species = new[] {632 ,074 ,304},
               Level = 23,
            },
            new HordeArea_XY
            {
               Location = 112, // Azure Bay
               Species = new[] {278 ,079 ,102},
               Level = 13,
            },
        };
    }
}