namespace pkm3dsRNG.Core
{
    public abstract class WildRNG : IGenerator
    {
        public int TSV;
        public bool ShinyCharm;
        public byte Synchro_Stat;
        public byte slot;
        public byte[] SlotSplitter;
        public int[] SpecForm;
        
        // Store personal info in memory
        public byte[] Gender;
        public bool[] RandomGender;
        public bool[] IV3;

        public virtual int PerfectIVCount { get; }
        public virtual int PIDroll_count { get; }

        public abstract RNGResult Generate();

        public byte getslot(int rand)
        {
            for (byte i = 1; i < SlotSplitter.Length; i++)
            {
                rand -= SlotSplitter[i - 1];
                if (rand < 0)
                    return slot = i;
            }
            return slot = (byte)SlotSplitter.Length;
        }
    }
}
