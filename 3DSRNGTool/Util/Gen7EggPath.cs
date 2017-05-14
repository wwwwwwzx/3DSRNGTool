using System.Collections.Generic;

namespace Pk3DSRNGTool
{
    public static class Gen7EggPath
    {
        private static int[] Pre; // Previous Node
        private static int[] W; // Weight
        const int accept = 1;
        const int reject = 1;
        public static List<int> Calc(int[] FrameAdvList)
        {
            // Initialize
            int Maxdist = FrameAdvList.Length - 1;
            Pre = new int[Maxdist + 1];
            W = new int[Maxdist + 1];
            for (int i = 1; i <= Maxdist; i++)
                W[i] = Maxdist * reject;
            // Calc
            for (int i = 0; i <= Maxdist; i++)
            {
                // Reject path
                if (i != 0 && W[i] > W[i - 1] + reject)
                {
                    Pre[i] = i - 1;
                    W[i] = W[i - 1] + reject;
                }
                // Accept Path
                int j = i;
                int k = j + FrameAdvList[j];
                while (k <= Maxdist)
                {
                    if (W[k] > W[j] + accept)
                    {
                        Pre[k] = j;
                        W[k] = W[j] + accept;
                    }
                    j = k;
                    k = j + FrameAdvList[j];
                }
            }
            // Summary
            List<int> Results = new List<int>();
            int node = Maxdist;
            do
            {
                Results.Add(node);
                node = Pre[node];
            }
            while (node != 0);
            Results.Add(0);
            Results.Reverse();
            return Results;
        }
    }
}
