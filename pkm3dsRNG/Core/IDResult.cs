namespace pkm3dsRNG.Core
{
    internal interface IDResult
    {
        ushort TID { get; set; }
        ushort SID { get; set; }
        ushort TSV { get; set; }
    }
}
