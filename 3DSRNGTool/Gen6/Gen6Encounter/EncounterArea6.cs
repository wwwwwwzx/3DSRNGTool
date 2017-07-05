using System;
using System.Linq;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public abstract class EncounterArea6 : EncounterArea
    {
        public override int Locationidx => Location + (idx << 9);
        public override int[] Species { get; set; } = new int[12];
        public byte[] Level = new byte[12];
    }

    public class EncounterArea_XY : EncounterArea6
    {
        private readonly static int[] XList = {};
        private readonly static int[] YList = {};

        public override bool VersionDifference => Species.Any(i => XList.Contains(i));

        public override int[] getSpecies(int ver, bool IsNight) => getSpecies(ver == 1);

        private int[] getSpecies(bool IsY)
        {
            int[] table = (int[])Species.Clone();
            if (IsY && VersionDifference)  // Replace ORAS species
                for (int i = 0; i < 12; i++)
                {
                    int idx = Array.IndexOf(XList, table[i]);
                    if (idx > -1)
                        table[i] = YList[idx];
                }
            return table;
        }
    }

    public class EncounterArea_ORAS : EncounterArea6
    {
        private readonly static int[] ORList = { 303, };
        private readonly static int[] ASList = { 302, };

        public override bool VersionDifference => Species.Any(i => ORList.Contains(i));

        public override int[] getSpecies(int ver, bool IsNight) => getSpecies(ver == 3);

        private int[] getSpecies(bool IsAS)
        {
            int[] table = (int[])Species.Clone();
            if (IsAS && VersionDifference)  // Replace ORAS species
                for (int i = 0; i < 12; i++)
                {
                    int idx = Array.IndexOf(ORList, table[i]);
                    if (idx > -1)
                        table[i] = ASList[idx];
                }
            return table;
        }
    }
}
