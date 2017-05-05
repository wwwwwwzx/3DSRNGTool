namespace Pk3DSRNGTool.Core
{
    internal interface IDResult
    {
        ushort TID { get; }
        ushort SID { get; }
        ushort TSV { get; }
    }
}
