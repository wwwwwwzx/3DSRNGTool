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

        public uint[] Status => Tinyrng.status;
        public void Next() => Tinyrng.Next();
        public uint Nextuint() => Tinyrng.Nextuint();
        public byte Rand(int n) => (byte)((Tinyrng.Nextuint() * (ulong)n) >> 32);
        public bool Rand2 => Tinyrng.Nextuint() < 0x80000000;

        public void Addfront(int f, int t) => list.Add(new TinyCall(f, t));
        public void Add(int f, int t)
        {
            list.Add(new TinyCall(f, t));
            if (list.Count > 1)
                list = list.OrderByDescending(e => e.frame).ThenBy(e => e.type).ToList();
        }
        public void RemoveType(int t) => list.RemoveAll(c => c.type == t);

        public void time_elapse(int Delay)
        {
            int Target = Currentframe + Delay;
            while (list.Last().frame < Target)
                AdvancetoNextCall();
            Currentframe = Target;
        }

        public uint AdvancetoNextCall()
        {
            uint rand = Tinyrng.Nextuint();
            if (list.Count == 0)
                return rand;
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
                case 3: // Fidget 0x70B108
                    Add(Currentframe + getcooldown3(rand), 3);
                    break;
                case 4: // Soaring 0x726ED4
                    Add(Currentframe + getcooldown4(rand), 4);
                    break;
                case 5: // XY ID 0x42BDF8
                    Add(Currentframe + getcooldown5(rand), 5);
                    break;
                case 6: // Running NPC 0x7D3B28
                    Add(Currentframe + 16, 6);
                    break;
                case 7: // Groudon/Kyogre 0x7BE438
                    Add(Currentframe + getcooldown7(rand), 7);
                    break;
                    /*
                    case 8: // Battle
                        Add(Currentframe + getcooldown6(rand), 8);
                        break;
                    */
            }
            return rand;
        }

        public static int getcooldown1(uint rand) => (int)((rand * 60ul) >> 32) * 2 + 124;
        public static int getcooldown2(uint rand) => rand > 0x55555555 ? 12 : 20;
        public static int getcooldown3(uint rand) => (int)((rand * 90ul) >> 32) * 2 + 780;
        public static int getcooldown4(uint rand) => rand % 3 == 0 ? 360 : 180;
        public static int getcooldown5(uint rand) => 542 - (int)((rand * 180ul) >> 32) * 2;
        public static int getcooldown7(uint rand) => (int)(((rand * 10ul) >> 32) * 30 + 60);
        // public static int getcooldown6(uint rand) => (int)(((rand * 240ul) >> 32) + 251);
    }

    public class TinyTimeline
    {
        private const int Buffer = 100;

        public TinyTimeline(uint[] Seeds) { TimelineStatus = new TinyStatus(Seeds); }
        public int Startingframe;
        public int Maxframe;
        public byte Method;
        public int P1;
        public int P2;
        public int PartySize => P1;
        public int SlotNum => P1;
        public int EncounterRate => P2;
        public int ChainLength => P2;
        public bool Boost;
        public bool IsORAS;
        public void Add(int f, int t) => TimelineStatus.Add(f, t);

        public List<Frame_Tiny> results;
        public int TinyLength => results.Count;

        // For timeline splitting
        public int Delay;
        public int CryFrame;
        private TinyStatus TimelineStatus;
        private List<TinyTimeSpan> ReferenceList;

        private struct TinyTimeSpan
        {
            public int Index;
            public uint rand;
            public int framemin;
            public int framemax;
            public TinyStatus tinystate;

            public bool R2 => rand < 0x80000000;
            public byte R100 => (byte)((rand * 100ul) >> 32);
            public Frame_Tiny Clone() => new Frame_Tiny
            {
                Index = Index,
                rand = rand,
                framemin = framemin,
                framemax = framemax,
                tinystate = tinystate,
            };
        }

        private TinyTimeSpan getNewSpan(int index) => new TinyTimeSpan()
        {
            Index = index,
            tinystate = TimelineStatus.Clone(),
            framemin = TimelineStatus.Currentframe,
            rand = TimelineStatus.AdvancetoNextCall(),
            framemax = TimelineStatus.Currentframe,
        };

        public void Generate(bool splittimeline = false, bool ForMainForm = false)
        {
            TimelineStatus.Currentframe = Startingframe - 2;
            int i = 0;
            ReferenceList = new List<TinyTimeSpan>();
            while (TimelineStatus.Currentframe <= Maxframe)
                ReferenceList.Add(getNewSpan(i++));
            int imax = i + Buffer;
            for (; i < imax;)
                ReferenceList.Add(getNewSpan(i++));
            if (splittimeline || ForMainForm && (Method < 2 || Method == 10))
                SplitTimeline(); // Consider delay effect
            else
                results = ReferenceList.Select(t => t.Clone()).ToList();
            if (ForMainForm && 1 < Method && Method < 9)
                return;
            switch (Method)
            {
                case 0: MarkSync(true); break;
                case 1: MarkSync(false); break;
                case 2: MarkHorde(); break;
                case 3: MarkEncounter(FS: true); break;
                case 4: MarkEncounter(Check: false); MarkRadar(); break;
                case 5: MarkEncounter(Fishing: true); break;
                case 6: MarkRockSmash(); break;
                case 7: MarkEncounter(Check: false); break;
                case 8: MarkEncounter(); break;
                case 10: MarkSync(true); break;
            }
            ReferenceList.Clear();
        }

        private int getidxAfterDelay(TinyStatus src, int Current, int startindex)
        {
            var st = src.Clone();
            st.Currentframe = Current;
            st.RemoveType(3); // Remove fidget

            // Delay
            switch (Method)
            {
                case 5:                 // Fishing
                    st.time_elapse(Delay);
                    for (int i = 3 * PartySize; i > 0; i--)
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
                case 10:
                    st.time_elapse(146);
                    st.Next();
                    if (Delay == 324)  // Kyogre
                    {
                        st.time_elapse(118);
                        st.Next();
                        st.time_elapse(60);
                    }
                    else               // Groudon
                        st.time_elapse(180);
                    for (int i = 3 * PartySize; i > 0; i--) // Memory
                        st.Next();
                    st.time_elapse(124);
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
            var hitstate = st.Status;
            for (int i = startindex; i < ReferenceList.Count; i++)
                if (ReferenceList[i].tinystate.Status.SequenceEqual(hitstate))
                    return i;
            return int.MaxValue;
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

        private void MarkSync(bool Instant) => getshiftedsync(Instant ? 0 : 3 * PartySize);

        private void getshiftedsync(int shift)
        {
            int idxmax = ReferenceList.Count - shift;
            results = results.TakeWhile(r => r.HitIndex < idxmax).ToList();  // Remove tail data
            foreach (var rt in results)
                rt.sync = ReferenceList[rt.HitIndex + shift].R2;
        }

        private void MarkEncounter(bool FS = false, bool Fishing = false, bool Check = true)
        {
            Frame_Tiny.thershold = (byte)(!Check ? 0 : EncounterRate);
            byte SlotType = (byte)(FS ? SlotNum + 47 : Fishing ? 3 : 2);
            int idxmax = ReferenceList.Count - 6;
            results = results.TakeWhile(r => r.HitIndex < idxmax).ToList();  // Remove tail data
            foreach (var rt in results)
            {
                int j = rt.HitIndex;
                rt.sync = ReferenceList[j++].R2;
                if (Check) rt.enctr = ReferenceList[j++].R100;
                rt.slot = WildRNG.getSlot(ReferenceList[j++].R100, SlotType);
                if (IsORAS) rt.flute = WildRNG.getFluteBoost(ReferenceList[j++].R100);
                rt.item = Wild6.getHeldItem(ReferenceList[++j].R100);
            }
        }

        private void MarkRockSmash()
        {
            Frame_Tiny.thershold = 1;
            int idxmax = ReferenceList.Count - 6;
            results = results.TakeWhile(r => r.HitIndex < idxmax).ToList();  // Remove tail data
            foreach (var rt in results)
            {
                int j = rt.HitIndex;
                rt.enctr = (byte)((ReferenceList[j++].rand * 3ul) >> 32);
                rt.sync = ReferenceList[j++].R2;
                rt.slot = WildRNG.getSlot(ReferenceList[j++].R100, 4);
                if (IsORAS) rt.flute = WildRNG.getFluteBoost(ReferenceList[j++].R100);
                rt.item = Wild6.getHeldItem(ReferenceList[++j].R100);
            }
        }

        private void MarkHorde()
        {
            foreach (var rt in results)
                rt.horde = new Horde(rt.tinystate.Status, PartySize, IsORAS);
        }

        private void MarkRadar()
        {
            foreach (var rt in results)
                rt.radar = new PokeRadar(rt.tinystate.Status, PartySize, ChainLength, Boost);
        }
    }
}