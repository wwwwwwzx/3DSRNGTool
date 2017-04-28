namespace pkm3dsRNG.RNG
{
    internal interface IRNG
    {
        void Next();
        uint Nextuint();
        void Reseed(uint seed);
    }

    internal interface IRNG64
    {
        ulong Next();
    }
}