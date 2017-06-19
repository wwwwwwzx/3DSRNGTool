namespace Pk3DSRNGTool
{
    public class Frame_Tiny
    {
        public int Index { get; set; }
        public bool _sync;
        public PRNGState state;
        public uint rand;
        public int framemin;
        public int framemax;
        
        public string Status => state.ToString();
        public char Sync => _sync ? 'O' : 'X';
        public ulong Rand100 => (rand * 100ul) >> 32;
        public string FrameRange => framemin == framemax ? "-" : (framemin + 2).ToString() + " ~ " + framemax.ToString();
        public bool hitable => framemin != framemax;
    }
}
