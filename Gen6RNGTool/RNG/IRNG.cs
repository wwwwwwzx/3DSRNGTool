namespace Gen6RNGTool.RNG
{
    internal interface IRNG
    {
        uint Next();
        uint Nextuint();
        void Reseed(uint seed);
    }

    internal interface IRNG64
    {
        ulong Next();
    }
}