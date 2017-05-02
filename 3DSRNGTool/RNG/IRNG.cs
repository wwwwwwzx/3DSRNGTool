namespace Pk3DSRNGTool.RNG
{
    internal interface IRNG
    {
        void Next();
        uint Nextuint();
        void Reseed(uint seed);
    }

    internal interface IRNG64 : IRNG
    {
        ulong Nextulong();
    }

    internal interface RNGState
    {
        string CurrentState();
    }
}