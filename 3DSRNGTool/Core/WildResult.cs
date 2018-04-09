namespace Pk3DSRNGTool.Core
{
    internal interface WildResult
    {
        byte Slot { get; set; }
        byte Item { get; set; }
        bool IsSpecial { get; set; }
    }
}
