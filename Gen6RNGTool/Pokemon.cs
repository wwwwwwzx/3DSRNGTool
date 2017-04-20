using System.Linq;

namespace Gen6RNGTool
{
    class Pokemon
    {
        public readonly static int[] SpecForm =
        {
            0,
            377,
            378,
            379,
            380,
            381,
            382,
            383,
            384,
            386,
        };
        public static bool ShinyLocked(int index)
        {
            //todo
            return true;
        }
        public readonly static byte[] Reorder1 = { 1, 2, 5, 3, 4 };    // In-game index to Normal index
        public readonly static byte[] Reorder2 = { 0, 1, 2, 4, 5, 3 }; // Normal index to In-Game index

        public static void NatureAdjustment(int[] stats, int nature)
        {
            byte inc = Reorder1[nature / 5];
            byte dec = Reorder1[nature % 5];
            if (inc == dec)
                return;
            stats[inc] = (int)(1.1 * stats[inc]);
            stats[dec] = (int)(0.9 * stats[dec]);
        }

        public static int getHiddenPowerValue(int[] IVs)
        {
            return 15 * IVs.Select((iv, i) => (iv & 1) << Reorder2[i]).Sum() / 63;
        }
    }
}
