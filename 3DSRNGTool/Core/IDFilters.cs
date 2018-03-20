using System.Collections.Generic;
using System.Linq;

namespace Pk3DSRNGTool.Core
{
    internal class IDFilters
    {
        public byte IDType;
        public bool Skip, RE;
        public string[] IDList;
        public string[] TSVList;
        public string[] RandList;
        private HashSet<int> tsvlist;
        private HashSet<uint> fullidlist;

        public void ParseString()
        {
            if (TSVList.Length > 0)
                tsvlist = new HashSet<int>(ToTSVList());
            if (IDList.Length > 0 && IDType == 2)
                fullidlist = new HashSet<uint>(ToFullID());
        }

        private IEnumerable<uint> ToFullID()
        {
            foreach (string A in IDList)
            {
                string input = A.Replace(" ", string.Empty); // Remove spaces
                int index = input.LastIndexOf("//");        // Allow Comments
                if (index > 0)
                    input = input.Substring(0, index);
                if (input.Contains("/"))
                {
                    string[] id = input.Split('/');
                    if (id.Length == 2 && uint.TryParse(id[0], out uint tid) && uint.TryParse(id[1], out uint sid))
                        yield return (sid << 16) | tid;
                }
                else if (uint.TryParse(input, System.Globalization.NumberStyles.HexNumber, null, out uint fullid))
                    yield return fullid;
            }
        }

        private IEnumerable<int> ToTSVList()
        {
            foreach (string A in TSVList)
                if (int.TryParse(A, out int val) && -1 < val && val < 4096)
                    yield return val;
        }

        private bool CheckID(IDResult ID)
        {
            switch (IDType)
            {
                case 0: return CheckID(string.Format("{0:D5}", ID.TID));
                case 1: return CheckID(string.Format("{0:D5}", ID.SID));
                case 2: return CheckID((uint)((ID.SID << 16) | ID.TID));
                case 3: return CheckID(string.Format("{0:D6}", (ID as ID7).G7TID));
                default: return false;
            }
        }

        private bool CheckID(string ID)
            => RE ? IDList.Any(id => System.Text.RegularExpressions.Regex.IsMatch(ID, id))
                  : IDList.Any(id => id != "" && ID.IndexOf(id, System.StringComparison.Ordinal) >= 0);

        private bool CheckID(uint ID)
            => fullidlist.Contains(ID);

        private bool CheckTSV(IDResult ID)
            => tsvlist.Contains(ID.TSV);

        private bool CheckRand(IDResult ID)
        {
            string Randstr = (ID as ID6)?.Status.ToString() ?? (ID as ID7)?.RandNum.ToString("X16");
            return RE ? RandList.Any(rand => System.Text.RegularExpressions.Regex.IsMatch(Randstr, rand))
                      : RandList.Any(rand => rand != "" && Randstr.IndexOf(rand.ToUpper(), System.StringComparison.Ordinal) >= 0);
        }

        public bool CheckResult(IDResult ID)
        {
            if (Skip)
                return true;
            if (IDList.Length != 0 && !CheckID(ID))
                return false;
            if (TSVList.Length != 0 && !CheckTSV(ID))
                return false;
            if (RandList.Length != 0 && !CheckRand(ID))
                return false;
            return true;
        }
    }
}
