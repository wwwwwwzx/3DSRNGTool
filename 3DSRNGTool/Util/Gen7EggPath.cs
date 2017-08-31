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
                W[i] = int.MaxValue; // Max int32
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
                for (int j = i, k = i + FrameAdvList[i]; k <= Maxdist; j = k, k = j + FrameAdvList[j])
                {
                    if (W[k] > W[j] + accept)
                    {
                        Pre[k] = j;
                        W[k] = W[j] + accept;
                    }
                }
            }
            // Summary
            List<int> Results = new List<int>();
            for (int node = Maxdist; node != 0; node = Pre[node]) // Track back
                Results.Add(node);
            Results.Add(0);
            Results.Reverse();
            return Results;
        }
    }
}
