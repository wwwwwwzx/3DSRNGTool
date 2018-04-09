using System;
using System.Linq;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    // Encounter Area for one specific Fishing Rod
    public class RodArea : EncounterArea
    {
        public override int Locationidx => Location + (idx << 9);
        public override int[] Species { get; set; } = new int[3];
        public byte[] Level = new byte[3];

        private readonly static int[] XList = { 692, 693 }; // Ignore Basculin form difference
        private readonly static int[] YList = { 690, 691 };

        public override bool VersionDifference => Species.Any(i => XList.Contains(i));
        public override int[] getSpecies(int ver, bool IsNight)
        {
            int[] table = (int[])Species.Clone();
            if (VersionDifference && ver == 1)  // Replace XY species; ORAS don't have version difference?
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
    }

    public class FishingArea6 : EncounterArea
    {
        public override int Locationidx => Location + (idx << 9);
        public override int[] Species { get; set; } = new int[9];
        public byte[] Level = new byte[9];
        public override int[] getSpecies(int ver, bool IsNight) => new int[3]; // Not using
        public RodArea GetRodArea(int RodSpecies)
        {
            int startingindex = 0;
            var sp = new int[3];
            var lvl = new byte[3];
            switch (RodSpecies)
            {
                case 129: startingindex = 0; break;
                case 349: startingindex = 3; break;
                case 130: startingindex = 6; break;
            }
            for (int i = 0; i < 3; i++)
            {
                sp[i] = Species[startingindex + i];
                lvl[i] = Level[startingindex + i];
            }
            return new RodArea
            {
                Location = Location,
                idx = idx,
                Species = sp,
                Level = lvl,
            };
        }
    }
}
