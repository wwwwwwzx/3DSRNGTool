using System.Collections.Generic;
using System.Linq;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public class TinyTimeline
    {
        #region subclass
        private class TinyCall
        {
            public int frame;
            public int type;
            public TinyCall(int f, int t)
            {
                frame = f;
                type = t;
            }
        }

        private class TinyCallList
        {
            private List<TinyCall> list = new List<TinyCall>();

            public void Addfront(int f, int t) => list.Add(new TinyCall(f, t));

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
        #endregion

        const int Buffer = 100;

        public int Startingframe;
        public int Maxframe;
        private TinyCallList Status = new TinyCallList();
        public TinyMT Tinyrng;

        public void Add(int f, int t) => Status.Add(f, t);
        public uint getrand => Tinyrng.Nextuint();
        public PRNGState State => Tinyrng.CurrentState();

        public List<Frame_Tiny> Generate()
        {
            int Currentframe = Startingframe - 2;
            int i = 0;
            var list = new List<Frame_Tiny>();
            while (Currentframe <= Maxframe)
            {
                var newdata = new Frame_Tiny();
                newdata.Index = i++;
                newdata.state = State;
                newdata.framemin = Currentframe;
                var call = Status.First();
                Currentframe = newdata.framemax = call.frame;
                newdata.rand = Tinyrng.Nextuint();
                switch (call.type)
                {
                    case 0:
                        Status.Addfront(Currentframe, newdata.rand < 0x55555556 ? 1 : 2);
                        break;
                    case 1:
                        Status.Addfront(Currentframe + getcooldown2(newdata.rand), 2);
                        break;
                    case 2:
                        Status.Addfront(Currentframe + getcooldown1(newdata.rand), 0);
                        break;
                    case 3:
                        Status.Addfront(Currentframe + 180, 3);
                        break;
                }
                list.Add(newdata);
            }
            int imax = i + Buffer;
            for (; i < imax; i++)
            {
                var newdata = new Frame_Tiny();
                newdata.Index = i;
                newdata.state = State;
                newdata.framemin = Currentframe;
                newdata.framemax = Currentframe;
                newdata.rand = Tinyrng.Nextuint();
                list.Add(newdata);
            }
            MarkSync(list);
            return list;
        }

        private void MarkSync(List<Frame_Tiny> list)
        {
            const int delay1 = 15;
            const int delay2 = 20;
            int max = list.Count - delay2;
            for (int i = 0; i < max; i++)
            {
                list[i]._sync = true;
                for (int j = i + delay1; j < i + delay2; j++)
                {
                    if (list[j].rand > 0x7FFFFFFF)
                    {
                        list[i]._sync = false;
                        break;
                    }
                }
            }
        }

        private static int getcooldown1(uint rand) => (int)((((rand * 60ul) >> 32) * 2 + 124));
        private static int getcooldown2(uint rand) => rand < 0x55555556 ? 20 : 12;
    }
}
