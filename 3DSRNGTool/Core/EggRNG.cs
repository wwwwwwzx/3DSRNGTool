namespace Pk3DSRNGTool.Core
{
    public abstract class EggRNG : IPKM, IGenerator
    {
        public short TSV { get; set; }
        public int[] MaleIVs { get; set; }
        public int[] FemaleIVs { get; set; }
        public byte MaleItem { get; set; }
        public byte FemaleItem { get; set; }
        public byte InheritAbilty { get; set; }

        public bool ShinyCharm, MMethod;

        public bool ConsiderOtherTSV;
        public int[] OtherTSVs;

        internal bool DestinyKnot { get; set; }
        internal bool EverStone { get; set; }
        internal bool Both_Everstone { get; set; }
        internal bool Power { get; set; }
        internal bool Both_Power { get; set; }
        internal byte M_Power { get; set; }
        internal byte F_Power { get; set; }

        internal byte PID_Rerollcount { get; set; }
        internal byte InheritIVs_Cnt { get; set; }
        internal bool RandomGender { get; set; }

        public abstract RNGResult Generate();
        public abstract void MarkItem();
    }
}
