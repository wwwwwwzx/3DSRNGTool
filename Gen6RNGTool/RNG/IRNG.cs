namespace Gen6RNGTool.RNG
{
    internal interface IRNG
    {
        //  All of our RNG functions must be able to return
        //  a simple unsigned 32 bit item, and that is it.
        uint Next();
        uint Nextuint();
        void Reseed(uint seed);
    }

    internal interface IRNG64
    {
        //  These RNG functions must be able to return
        //  a simple unsigned 64 bit item, and that is it.
        ulong Next();
    }
}