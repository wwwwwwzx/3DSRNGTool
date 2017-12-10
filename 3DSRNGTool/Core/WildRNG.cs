namespace Pk3DSRNGTool.Core
{
    public abstract class WildRNG : IGenerator
    {
        public int TSV;
        public bool ShinyCharm;
        public byte Synchro_Stat;

        public byte[] SlotSplitter;
        public int[] SpecForm;

        // Store personal info in memory
        protected byte[] Gender;
        protected bool[] RandomGender;
        protected bool[] IV3;
        protected byte slot;

        protected virtual int PerfectIVCount => IV3[slot] ? 3 : 0;
        protected virtual int PIDroll_count { get; }

        public virtual void Delay() { }
        public abstract RNGResult Generate();
        public abstract void Markslots();

        protected byte getslot(int rand)
        {
            for (byte i = 1; i < SlotSplitter.Length; i++)
            {
                rand -= SlotSplitter[i - 1];
                if (rand < 0)
                    return slot = i;
            }
            return slot = (byte)SlotSplitter.Length;
        }

        public readonly static byte[][] SlotDistribution = new byte[][]
        {
            new byte[] { 20,20,10,10,10,10,10,5,4,1 }, //SuMo Normal
            new byte[] { 10,10,20,20,10,10,10,5,4,1 }, //SuMo Poni Plains
            new byte[] { 10,10,10,10,10,10,10,10,10,5,4,1 }, // Gen6
            new byte[] { 60,35,5 }, // Horde / Fishing
            new byte[] { 50,30,15,4,1 }, // Rock Smash
             // Gen7 Fishing
            new byte[] { 90,10 }, // 5
            new byte[] { 40,60 },
            new byte[] { 35,35,05,25, }, // 7
            new byte[] { 25,25,35,15, },
            new byte[] { 25,25,25,05,05,15, }, // 9
            new byte[] { 15,15,15,35,05,15, },
            new byte[] { 44,30,25,01, }, // 11
            new byte[] { 40,25,25,10, },
            new byte[] { 55,40,05 }, // 13
            new byte[] { 45,20,35, },
            new byte[] { 50,30,05,15 }, // 15
            new byte[] { 40,20,35,05 },
            new byte[] { 20,15,50,15 }, // 17
            new byte[] { 10,05,80,05 },
            new byte[] { 50,40,05,05 }, // 19
            new byte[] { 20,10,35,35 },
            new byte[] { 45,25,05,25 }, // 21
            new byte[] { 25,20,35,20 },
            new byte[] { 59,40,01 }, // 23
            new byte[] { 50,40,10 },
        };
    }
}
