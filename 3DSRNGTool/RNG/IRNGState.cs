using System.Linq;

namespace Pk3DSRNGTool
{
    public class PRNGState
    {
        private uint? state1;
        private uint[] state2;

        public PRNGState(uint s)
        {
            state1 = s;
        }

        public PRNGState(uint[] s)
        {
            state2 = (uint[])s.Clone();
        }

        public override string ToString() => state1?.ToString("X8") ?? string.Join(",", state2.Select(v => v.ToString("X8")).Reverse());
    }

    internal interface IRNGState
    {
        PRNGState CurrentState();
    }
}
