using System.Collections.Generic;
using System.Linq;

namespace Pk3DSRNGTool
{
    internal class TinyCall
    {
        public int frame;
        public int type;
        public TinyCall(int f, int t)
        {
            frame = f;
            type = t;
        }
    }

    internal class TinyCallList
    {
        public List<TinyCall> list = new List<TinyCall>();

        public void Addfront(int f, int t)
        {
            list.Add(new TinyCall(f, t));
        }

        public void Add(int f, int t)
        {
            list.Add(new TinyCall(f, t));
            list = list.OrderByDescending(e => e.frame).ToList();
        }

        public TinyCall First()
        {
            var tmp = new TinyCall(list.Last().frame, list.Last().type);
            list.RemoveAt(list.Count - 1);
            return tmp;
        }
    }
}
