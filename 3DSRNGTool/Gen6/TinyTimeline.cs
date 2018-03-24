using System;
using System.Linq;
using System.Collections.Generic;
using Pk3DSRNGTool.RNG;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public class TinyStatus
    {
        private struct TinyCall
        {
            public int frame, type;
            public TinyCall(int f, int t) { frame = f; type = t; }
        }

        private List<TinyCall> list = new List<TinyCall>();
        public TinyMT Tinyrng;
        public int Currentframe;
        public TinyStatus(uint[] seed)
        {
            Tinyrng = new TinyMT(seed);
        }
        public TinyStatus Clone() => new TinyStatus(Tinyrng.status)
        {
            Currentframe = Currentframe,
            list = new List<TinyCall>(list),
        };

        public void Next() => Tinyrng.Next();
        public uint Nextuint() => Tinyrng.Nextuint();
        public byte Rand(int n) => (byte)((Tinyrng.Nextuint() * (ulong)n) >> 32);
        public bool Rand2 => Tinyrng.Nextuint() < 0x80000000;

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
        public static int getcooldown2(uint rand) => rand > 0x55555555 ? 12 : 20;
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

            public bool R2 => rand < 0x80000000;
            public byte R100 => (byte)((rand * 100ul) >> 32);
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
                newdata.tinystate = Status.Clone();
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
                newdata.tinystate = Status.Clone();
                Status.AdvancetoNextCall(out newdata.rand);
                newdata.framemax = Currentframe;
                ReferenceList.Add(newdata);
            }
            if (splittimeline)
                SplitTimeline(); // Consider delay effect
            else
                results = ReferenceList.Select(t => t.Clone()).ToList();
            switch (Method)
            {
                case 0: MarkSync(true); break;
                case 1: MarkSync(false); break;
                case 2: MarkHorde(); break;
                case 3: MarkFS(); break;
                case 4: MarkNormalWild(); break;
                case 5: MarkFishing(); break;
                case 6: MarkRockSmash(); break;
                case 7: MarkNormalWild(); break;
            }
        }

        private int getidxAfterDelay(TinyStatus src, int Current, int startindex)
        {
            var st = src.Clone();
            st.Currentframe = Current;

            // Delay
            switch (Method)
            {
                case 5:                 // Fishing
                    st.time_elapse(Delay);
                    for (int i = 3 * PM_Num; i > 0; i--)
                        st.Next();
                    st.time_elapse(132);
                    st.time_elapse(st.Rand(7) * 30 + 60);
                    break;
                case 6:                 // Rock Smash
                    st.time_elapse(16);
                    for (int i = 3; i > 0; i--) // Memory for Rock Smasher
                        st.Next();
                    st.time_elapse(Delay - 228);
                    st.Next(); // Rand(240)
                    st.time_elapse(212);
                    break;
                default:
                    if (CryFrame == -1) // No Cry
                        st.time_elapse(Delay);
                    else
                    {
                        st.time_elapse(CryFrame);
                        st.Next();
                        st.time_elapse(Delay - CryFrame);
                    }
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
                // Check if it's new CurrTiny
                CurrHitidx = CurrMTF == CurrTinyF.framemin + 2 ? getidxAfterDelay(CurrTinyF.tinystate, CurrMTF, CurrTinyF.Index) : Hitidx;
                var newdata = CurrTinyF.Clone();
                newdata.framemin = CurrMTF - 2;
                newdata.HitIndex = CurrHitidx;
                do
                {
                    CurrMTF += 2;
                    Hitidx = getidxAfterDelay(CurrTinyF.tinystate, CurrMTF, CurrTinyF.Index);
                }
                while (CurrMTF <= CurrTinyF.framemax && CurrHitidx == Hitidx); // Still inside one frame, loop until new result
                newdata.framemax = CurrMTF - 2;
                results.Add(newdata);
            }
        }

        private int PM_Num => Parameter;
        private int SlotNum => Parameter;

        private void MarkSync(bool Instant) => getshiftedsync(Instant ? 0 : 3 * PM_Num);

        private void getshiftedsync(int shift)
        {
            int max = results.Count;
            int idxmax = ReferenceList.Count;
            int framehit;
            for (int i = 0; i < max; i++)
            {
                framehit = results[i].HitIndex + shift;
                if (framehit >= idxmax)
                {
                    results = results.Take(i).ToList(); // Remove Tail Data
                    break;
                }
                results[i].sync = ReferenceList[framehit].R2;
            }
        }

        private void MarkFS()
        {
            Frame_Tiny.thershold = 13;
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
                results[i].sync = ReferenceList[j++].R2;
                results[i].enctr = ReferenceList[j++].R100;
                results[i].slot = Wild6.getFSSlot(SlotNum, ReferenceList[j++].R100);
                results[i].item = Wild6.getItem(ReferenceList[++j].R100);
            }
        }

        private void MarkRockSmash()
        {
            byte getrocksmashslot(uint rand)
            {
                if (rand < 50)
                    return 1;
                if (rand < 80)
                    return 2;
                if (rand < 95)
                    return 3;
                if (rand < 99)
                    return 4;
                return 5;
            }
            Frame_Tiny.thershold = 1;
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
                results[i].enctr = (byte)((ReferenceList[j++].rand * 3ul) >> 32);
                results[i].sync = ReferenceList[j++].R2;
                results[i].slot = getrocksmashslot(ReferenceList[j++].R100);
                results[i].Flute = WildRNG.getFluteBoost(ReferenceList[j++].R100);
                results[i].item = Wild6.getItem(ReferenceList[j].R100);
            }
        }

        private void MarkNormalWild()
        {
            int max = results.Count;
            int idxmax = ReferenceList.Count - 4;
            for (int i = 0; i < max; i++)
            {
                int j = results[i].HitIndex;
                if (j >= idxmax)
                {
                    results = results.Take(i).ToList(); // Remove Tail Data
                    break;
                }
                results[i].sync = ReferenceList[j++].R2;
                results[i].slot = FuncUtil.getgen6slot(ReferenceList[j++].rand);
                results[i].Flute = WildRNG.getFluteBoost(ReferenceList[j++].R100);
                results[i].item = Wild6.getItem(ReferenceList[j].R100);
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
            byte getfishingslot(uint rand)
            {
                if (rand < 50)
                    return 1;
                if (rand < 95)
                    return 2;
                return 3;
            }
            Frame_Tiny.thershold = 98;
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
                results[i].sync = ReferenceList[j++].R2;
                results[i].enctr = ReferenceList[j++].R100;
                results[i].slot = getfishingslot(ReferenceList[j++].R100);
                results[i].Flute = WildRNG.getFluteBoost(ReferenceList[j++].R100);
                results[i].item = Wild6.getItem(ReferenceList[j].R100);
            }
        }
    }
}