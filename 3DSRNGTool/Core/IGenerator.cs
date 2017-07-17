namespace Pk3DSRNGTool.Core
{
    internal interface IGenerator
    {
        void Delay();
        RNGResult Generate();
    }
}
