using System;
using System.Linq;
using System.Collections.Generic;
using Pk3DSRNGTool.RNG;

namespace Pk3DSRNGTool
{
    [Serializable()]
    public class TinyStatus
    {
        private List<TinyCall> list = new List<TinyCall>();
        public TinyMT Tinyrng;
        public int Currentframe;
        public byte csync;
        public TinyStatus(uint[] seed)
        {
            Tinyrng = new TinyMT(seed);
        }

        public void Next() => Tinyrng.Next();
        public uint Nextuint() => Tinyrng.Nextuint();
        public byte Rand(int n) => (byte)((Tinyrng.Nextuint() * (ulong)n) >> 32);
        public bool Rand2 => Tinyrng.Nextuint() < 0x80000000;

        [Serializable()]
        private struct TinyCall
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

        public void time_elapse(int Delay)
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
                    Addfront(Currentframe, rand > 0x55555555 ? 1 : 2);
                    break;
                case 1: // Blink 0x72B9E4
                    Add(Currentframe + getcooldown1(rand), 0);
                    break;
                case 2: // Blink 0x72B9FC
                    Add(Currentframe + getcooldown2(rand), 1);
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

        public static int getcooldown1(uint rand) => (int)((((rand * 60ul) >> 32) * 2 + 124));
        public static int getcooldown2(uint rand) => rand < 0x55555556 ? 20 : 12;
        public static int getcooldown3(uint rand) => (int)((((rand * 90ul) >> 32) * 2 + 780));
        public static int getcooldown4(uint rand) => rand % 3 == 0 ? 360 : 180;
        public static int getcooldown5(uint rand) => (int)((((rand * 10ul) >> 32) * 30 + 60));
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

        // Not in the timeline
        public int Delay;
        public int CryFrame;

        private struct TinyTimeSpan
        {
            public int Index;
            public uint[] state;
            public uint rand;
            public int framemin;
            public int framemax;
            public TinyStatus tinystate;

            public bool Rand2 => rand < 0x80000000;
            public byte Rand(uint n) => (byte)((rand * (ulong)n) >> 32);
            public Frame_Tiny Clone()
            {
                return new Frame_Tiny
                {
                    Index = Index,
                    state = (uint[])state.Clone(),
                    rand = rand,
                    framemin = framemin,
                    framemax = framemax,
                    tinystate = tinystate,
                };
            }
        }

        public int TinyLength => results.Count;
        private List<TinyTimeSpan> ReferenceList;
        public List<Frame_Tiny> results;
        public Frame_Tiny FindFrame(int frame) => results?.FirstOrDefault(t => t.framemin < frame && frame <= t.framemax);

        public void Generate(bool splittimeline = false)
        {
            Currentframe = Startingframe - 2;
            int i = 0;
            ReferenceList = new List<TinyTimeSpan>();
            while (Currentframe <= Maxframe)
            {
                var newdata = new TinyTimeSpan();
                newdata.Index = i++;
                newdata.state = State;
                newdata.framemin = Currentframe;
                newdata.tinystate = (TinyStatus)Status.DeepCopy();
                Status.AdvancetoNextCall(out newdata.rand);
                newdata.framemax = Currentframe;
                ReferenceList.Add(newdata);
            }
            int imax = i + Buffer;
            for (; i < imax;)
            {
                var newdata = new TinyTimeSpan();
                newdata.Index = i++;
                newdata.state = State;
                newdata.framemin = Currentframe;
                newdata.tinystate = (TinyStatus)Status.DeepCopy();
                Status.AdvancetoNextCall(out newdata.rand);
                newdata.framemax = Currentframe;
                ReferenceList.Add(newdata);
            }
            if (splittimeline)
                SplitTimeline(); // Consider delay effect
            else
            {
                results = ReferenceList.Select(t => t.Clone()).ToList();
                results.Select(t => t.HitIndex = t.Index); // Copy index
            }
            switch (Method)
            {
                case 0: MarkSync(true); break;
                case 1: MarkSync(false); break;
                case 2: MarkHorde(); break;
                case 3: MarkFS(); break;
                case 4: MarkNormalWild(); break;
                case 5: if (splittimeline) MarkFishing(); break;
                case 6:
                case 7: MarkNormalWild(); break;
            }
        }

        private int getidxAfterDelay(TinyStatus src, int Current, int startindex)
        {
            // No Cry
            var st = (TinyStatus)src.DeepCopy();
            st.Currentframe = Current;

            // Delay
            if (CryFrame == -1)
                st.time_elapse(Delay);
            else
            {
                st.time_elapse(CryFrame);
                st.Next();
                st.time_elapse(Delay - CryFrame);
            }

            // More method here
            switch (Method)
            {
                case 5:
                    for (int i = 3 * PM_Num; i > 0; i--)
                        st.Next();
                    st.time_elapse(132);
                    st.time_elapse(st.Rand(7) * 30 + 60);
                    break;
                case 6:
                    for (int i = 3; i > 0; i--)
                        st.Next();
                    st.time_elapse(52);
                    st.Next();
                    st.time_elapse(212);
                    break;
            }

            // Check hit idx
            var hitstate = st.Tinyrng.status;
            for (int i = startindex; i < ReferenceList.Count; i++)
            {
                if (ReferenceList[i].state.SequenceEqual(hitstate))
                    return i;
            }
            return -1;
        }

        private void SplitTimeline()
        {
            // Initialize
            results?.Clear();
            results = new List<Frame_Tiny>();
            int CurrMTF = Startingframe + 2; // Current MT Frame
            int Curridx = 0;  // Current Frame_Tiny idx
            int Hitidx = -1;  // Actual hit idx 
            int CurrHitidx = 0; // Current hit idx
            var CurrTinyF = ReferenceList[0]; // Current Frame_Tiny

            // BRUTEFORCE CHECK
            while (CurrMTF <= Maxframe)
            {
                while (CurrMTF > CurrTinyF.framemax || CurrTinyF.framemin == CurrTinyF.framemax) // If it's old breakpoint, then move to next
                {
                    CurrTinyF = ReferenceList[++Curridx];
                    if (CurrTinyF.framemin > Maxframe)
                        return;
                }
                CurrHitidx = getidxAfterDelay(CurrTinyF.tinystate, CurrMTF, CurrTinyF.Index);
                var newdata = CurrTinyF.Clone();
                newdata.framemin = CurrMTF - 2;
                do
                {
                    CurrMTF += 2;
                    Hitidx = getidxAfterDelay(CurrTinyF.tinystate, CurrMTF, CurrTinyF.Index);
                }
                while (CurrMTF <= CurrTinyF.framemax && CurrHitidx == Hitidx); // Still inside one frame
                newdata.framemax = CurrMTF - 2;
                newdata.HitIndex = CurrHitidx;
                results.Add(newdata);
                CurrHitidx = Hitidx;
            }
        }

        private int PM_Num => Parameter;
        private int SlotNum => Parameter;

        private void MarkSync(bool Instant)
        {
            int max = results.Count;
            if (Instant)
            {
                for (int i = 0; i < max; i++)
                    results[i].sync = ReferenceList[results[i].HitIndex].Rand2;
            }
            else
            {
                for (int i = 0; i < max; i++)
                    results[i].csync = getcsync(results[i].HitIndex);
            }
        }

        private void MarkFS()
        {
            int max = results.Count;
            int idxmax = ReferenceList.Count - 5;
            for (int i = 0; i < max; i++)
            {
                int j = results[i].HitIndex;
                if (j >= idxmax)
                {
                    results = results.Take(i).ToList(); // Remove Tail Data
                    break;
                }
                results[i].sync = ReferenceList[j++].Rand2;
                results[i].enctr = ReferenceList[j++].Rand(100);
                results[i].slot = (byte)(((ReferenceList[j++].rand * SlotNum) >> 32) + 1);
                results[i].item = getItem(ReferenceList[++j].Rand(100));
            }
        }

        private void MarkNormalWild()
        {
            int max = results.Count;
            int idxmax = ReferenceList.Count - 3;
            for (int i = 0; i < max; i++)
            {
                int j = results[i].HitIndex;
                if (j >= idxmax)
                {
                    results = results.Take(i).ToList(); // Remove Tail Data
                    break;
                }
                results[i].sync = ReferenceList[j++].Rand2;
                results[i].slot = FuncUtil.getgen6slot(ReferenceList[j++].rand);
                results[i].item = getItem(ReferenceList[++j].Rand(100));
            }
        }

        private void MarkHorde()
        {
            int max = results.Count;
            for (int i = 0; i < max; i++)
                results[i].horde = new HordeResults(new TinyMT(results[i].state), PM_Num);
        }


        public void MarkFishing()
        {
            int max = results.Count;
            int idxmax = ReferenceList.Count - 5;
            for (int i = 0; i < max; i++)
            {
                int j = results[i].HitIndex;
                if (j >= idxmax)
                {
                    results = results.Take(i).ToList(); // Remove Tail Data
                    break;
                }
                results[i].sync = ReferenceList[j++].Rand2;
                results[i].enctr = ReferenceList[j++].Rand(100);
                results[i].slot = getfishingslot(ReferenceList[j++].Rand(100));
                results[i].item = getItem(ReferenceList[++j].Rand(100));
            }
        }

        public byte getcsync(int hitidx)
        {
            int csync = 0;
            int weight = 2 * PM_Num + 1;
            int max = Math.Min(hitidx + 4 * PM_Num, ReferenceList.Count - 1);
            for (int i = hitidx + 3 * PM_Num; i <= max; i++, weight -= 2)
                if (ReferenceList[i].Rand2)
                    csync += weight;
            return (byte)(csync * 100 / ((PM_Num + 1) * (PM_Num + 1)));
        }

        private static byte getItem(uint rand)
        {
            if (rand < 50)
                return 0;
            if (rand < 55)
                return 1;
            if (rand < 56)
                return 2;
            return 3;
        }

        private static byte getfishingslot(uint rand)
        {
            if (rand < 50)
                return 1;
            if (rand < 95)
                return 2;
            return 3;
        }
    }
}