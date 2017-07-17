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
            new byte[] { 60,35,5 }, // Horde
            new byte[] { 50,30,15,4,1 }, // Rock Smash
        };
    }
}
