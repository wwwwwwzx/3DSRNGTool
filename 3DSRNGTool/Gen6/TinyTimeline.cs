using System.Linq;
using System.Collections.Generic;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    public class TinyStatus
    {
        private List<TinyCall> list = new List<TinyCall>();
        public TinyMT Tinyrng;
        public int Currentframe;
        public byte csync;

        public TinyStatus(uint[] seed, int Current = 0)
        {
            Tinyrng = new TinyMT(seed);
            Currentframe = Current;
        }

        public uint Nextuint() => Tinyrng.Nextuint();

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

        public void Addfront(int f, int t) => list.Add(new TinyCall(f, t));
        public void Add(int f, int t)
        {
            if (t < 0) return;
            list.Add(new TinyCall(f, t));
            list = list.OrderByDescending(e => e.frame).ToList();
        }

        public void AdvanceMT(int Delay)
        {
            int Target = Currentframe + Delay;
            while (list.Last().frame < Target)
                AdvancetoNextCall(out uint dumb);
            Currentframe = Target;
        }

        public void AdvancetoNextCall(out uint rand)
        {
            rand = Tinyrng.Nextuint();
            if (list.Count == 0)
                return;
            Currentframe = list.Last().frame;
            var calltype = list.Last().type;
            list.RemoveAt(list.Count - 1);
            switch (calltype)
            {
                case 0: // Blink 0x72B9D0
                    Addfront(Currentframe, rand < 0x55555556 ? 1 : 2);
                    break;
                case 1: // Blink 0x72B9FC
                    Add(Currentframe + getcooldown2(rand), 2);
                    break;
                case 2: // Blink 0x72B9E4
                    Add(Currentframe + getcooldown1(rand), 0);
                    break;
                case 3: // Stretch 0x70B108
                    Add(Currentframe + getcooldown3(rand), 3);
                    break;
                case 4: // Soaring 0x726ED4
                    Add(Currentframe + getcooldown4(rand), 4);
                    break;
                case 5: // Cry 0x3F05BC
                    break;
                case 6: // Groudon/Kyogre 0x7BE438
                    Add(Currentframe + getcooldown5(rand), 6);
                    break;
            }
        }

        private static int getcooldown1(uint rand) => (int)((((rand * 60ul) >> 32) * 2 + 124));
        private static int getcooldown2(uint rand) => rand < 0x55555556 ? 20 : 12;
        private static int getcooldown3(uint rand) => (int)((((rand * 90ul) >> 32) * 2 + 720));
        private static int getcooldown4(uint rand) => rand % 3 == 0 ? 360 : 180;
        private static int getcooldown5(uint rand) => (int)((((rand * 10ul) >> 32) * 30 + 60));
    }

    public class TinyTimeline
    {
        public const int Buffer = 100;

        public int Startingframe;
        public int Maxframe;
        public byte Method;
        public int Parameter;
        public TinyStatus Status;
        public void Add(int f, int t) => Status.Add(f, t);
        public uint getrand => Status.Tinyrng.Nextuint();
        public int Currentframe { get => Status.Currentframe; set => Status.Currentframe = value; }
        public uint[] State => (uint[])Status.Tinyrng.status.Clone();

        public int TinyLength => results.Count - Buffer;
        public List<Frame_Tiny> results;
        public Frame_Tiny FindFrame(int frame) => results?.FirstOrDefault(t => t.framemin < frame && frame <= t.framemax);

        public void Generate()
        {
            Currentframe = Startingframe - 2;
            int i = 0;
            results = new List<Frame_Tiny>();
            while (Currentframe <= Maxframe)
            {
                var newdata = new Frame_Tiny();
                newdata.Index = i++;
                newdata.state = State;
                newdata.framemin = Currentframe;
                Status.AdvancetoNextCall(out newdata.rand);
                newdata.framemax = Currentframe;
                results.Add(newdata);
            }
            int imax = i + Buffer;
            for (; i < imax; i++)
                results.Add(new Frame_Tiny()
                {
                    Index = i,
                    state = State,
                    framemin = Currentframe,
                    framemax = Currentframe,
                    rand = getrand,
                });
            switch (Method)
            {
                case 0: MarkFS(); break;
                case 2: MarkSync(); break;
            }
        }

        private int PM_Num => Parameter;
        private int SlotNum => Parameter;

        public void MarkSync()
        {
            int delay1 = 3 * PM_Num;
            int delay2 = 4 * PM_Num;
            int pos = PM_Num + 1; // Possible advance
            int weight = pos * pos;
            int max = results.Count - delay2;
            for (int i = 0; i < max; i++)
            {
                for (int j = pos; j > 0; j--)
                    if (results[i + delay2 - j + 1].rand2)
                        results[i].csync += 2 * j - 1;
                results[i].csync = (byte)((results[i].csync * 100) / weight);
            }
        }

        public void MarkFS()
        {
            int max = results.Count - 2;
            for (int i = 0; i < max; i++)
            {
                if (results[i + 1].Rand100 < 13)
                    results[i]._fs = (byte)(((results[i + 2].rand * SlotNum) >> 32) + 1);
            }
        }
    }
}
