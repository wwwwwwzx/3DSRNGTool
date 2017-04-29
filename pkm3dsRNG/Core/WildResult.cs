namespace pkm3dsRNG.Core
{
    internal interface WildResult
    {
        byte Slot { get; set; }
        byte Item { get; set; }
        bool IsSpecial { get; set; }
    }
}
