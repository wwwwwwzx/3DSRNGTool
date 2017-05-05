namespace Pk3DSRNGTool.Core
{
    public abstract class EggRNG : IPKM, IGenerator
    {
        public ushort TSV { get; set; }
        public int[] MaleIVs { get; set; }
        public int[] FemaleIVs { get; set; }
        public byte MaleItem { get; set; }
        public byte FemaleItem { get; set; }
        public byte InheritAbility { get; set; }

        public bool ShinyCharm, MMethod, NidoType;

        public bool ConsiderOtherTSV;
        public int[] OtherTSVs;

        protected bool DestinyKnot { get; set; }
        protected bool EverStone { get; set; }
        protected bool Both_Everstone { get; set; }
        protected bool Power { get; set; }
        protected bool Both_Power { get; set; }
        protected byte M_Power { get; set; }
        protected byte F_Power { get; set; }

        protected byte PID_Rerollcount { get; set; }
        protected byte InheritIVs_Cnt { get; set; }
        protected bool RandomGender { get; set; }

        public abstract RNGResult Generate();
        public abstract void MarkItem();
    }
}
