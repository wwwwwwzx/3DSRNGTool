using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Pk3DSRNGTool.RNG;
using Pk3DSRNGTool.Core;

namespace Pk3DSRNGTool
{
    public partial class MainForm : Form
    {
        #region Gen6 Search
        private void Search6()
        {
            switch (Method)
            {
                case 0 when CreateTimeline.Checked:
                case 2 when CreateTimeline.Checked:
                    Search6_Timeline(); return;
                case 2 when IsHorde:
                    Search6_Horde(); return;
                case 3:
                    Search6_Egg(); return;
                case 4:
                    Search6_ID(); return;
                default:
                    Search6_Normal(); return;
            }
        }

        private void Search6_Normal()
        {
            var rng = new MersenneTwister(Seed.Value);
            int min = (int)Frame_min.Value;
            int max = (int)Frame_max.Value;
            if (AroundTarget.Checked)
            {
                min = (int)TargetFrame.Value - 100; max = (int)TargetFrame.Value + 100;
            }
            // Advance
            for (int i = 0; i < min; i++)
                rng.Next();
            // Prepare
            getsetting(rng);
            // Start
            for (int i = min; i <= max; i++, RNGPool.AddNext(rng))
            {
                RNGResult result = RNGPool.Generate6();
                if (!filter.CheckResult(result))
                    continue;
                Frames.Add(new Frame(result, frame: i, time: i - min));
                if (Frames.Count > MAX_RESULTS_NUM)
                    break;
            }
        }

        private void Search6_Timeline()
        {
            if (!TTT.HasSeed)
            {
                FormUtil.Error("Please Calibrate Timeline");
                return;
            }

            var timeline = TTT.gettimeline();
            int min = Math.Max((int)Frame_min.Value, timeline.Startingframe + 2);
            int max = (int)TimeSpan.Value * 60 + min;
            timeline.Maxframe = max;
            timeline.Generate(ForMainForm: true);
            int listlength = timeline.TinyLength;

            // Prepare
            var rng = new MersenneTwister(Seed.Value);
            for (int i = 0; i < min; i++)
                rng.Next();
            getsetting(rng);
            Frame.standard = (int)(TargetFrame.Value - min);

            for (int i = 0; i < listlength; i++)
            {
                var tinyframe = timeline.results[i];
                if (tinyframe.unhitable)
                    continue;
                if (tinyframe.framemax < min)
                    continue;
                RNGPool.TinySynced = tinyframe.sync == true; // For stationary
                for (int j = tinyframe.framemin + 2; j <= tinyframe.framemax; j += 2, RNGPool.AddNext(rng), RNGPool.AddNext(rng))
                {
                    while (j < min)
                        j += 2;
                    RNGPool.tinystatus = tinyframe.tinystate.Clone();
                    RNGPool.tinystatus.Currentframe = j;
                    RNGResult result = RNGPool.Generate6();
                    if (!filter.CheckResult(result))
                        continue;
                    Frames.Add(new Frame(result, frame: j, time: j - min));
                    Frames.Last()._tinystate = new PRNGState(tinyframe.tinystate.Status);
                    if (Frames.Count > MAX_RESULTS_NUM)
                        return;
                }
            }
        }

        private void Search6_Horde()
        {
            var rng = new MersenneTwister(Seed.Value);
            int min = (int)Frame_min.Value;
            int max = (int)Frame_max.Value;
            if (AroundTarget.Checked)
            {
                min = (int)TargetFrame.Value - 100; max = (int)TargetFrame.Value + 100;
            }
            // Advance
            for (int i = 0; i < min; i++)
                rng.Next();
            // Prepare
            if (FullInfoHorde)
            {
                RNGPool.horde = new Horde(TTT.Gen6Tiny, (int)TTT.Parameter1.Value, IsORAS);
                SlotSpecies.SelectedValue = slotspecies[RNGPool.horde.Slot - 1];
            }
            if (SlotSpecies.SelectedIndex > 0)
            {
                var Hordespecies = (ea as HordeArea).getSpecies(Ver, (byte)SlotSpecies.SelectedIndex);
                L_HordeInfo.Text = "Species: " + string.Join(" \t", Hordespecies.Select(t => StringItem.speciestr[t])) + Environment.NewLine;
            }
            L_HordeInfo.Text += RNGPool.horde?.ToString() ?? string.Empty;
            getsetting(rng);
            // Start
            for (int i = min; i <= max; i++, RNGPool.AddNext(rng))
            {
                var results = RNGPool.GenerateHorde6();
                foreach (var result in results)
                {
                    if (!filter.CheckResult(result))
                        continue;
                    Frames.Add(new Frame(result, frame: i, time: i - min));
                }
                if (Frames.Count > MAX_RESULTS_NUM)
                    break;
            }
        }

        private void Search6_Egg()
        {
            var rng = new MersenneTwister(Seed.Value);
            int min = (int)Frame_min.Value;
            int max = (int)Frame_max.Value;
            if (AroundTarget.Checked)
            {
                min = (int)TargetFrame.Value - 100; max = (int)TargetFrame.Value + 100;
            }
            // Advance
            for (int i = 0; i < min; i++)
                rng.Next();
            // Prepare
            getsetting(rng);

            // The egg already have
            uint[] key = { Key0.Value, Key1.Value };
            Egg6 IG = RNGPool.igenerator as Egg6;
            var eggnow = IG.Generate(null, key) as ResultE6;
            eggnow.hiddenpower = (byte)Pokemon.getHiddenPowerValue(eggnow.IVs);
            if (IG.IsMainRNGEgg) eggnow.PID = 0xFFFFFFFF;
            eggnow.Status = "Current";
            Frames.Add(new Frame(eggnow, frame: -1));

            // Start
            for (int i = min; i <= max; i++, RNGPool.AddNext(rng))
            {
                var result = RNGPool.Generate6();
                if (!filter.CheckResult(result))
                    continue;
                Frames.Add(new Frame(result, frame: i, time: i - min));
                if (Frames.Count > MAX_RESULTS_NUM)
                    return;
            }
        }

        private void Search6_ID()
        {
            var rng = new TinyMT(new uint[] { ID_Tiny0.Value, ID_Tiny1.Value, ID_Tiny2.Value, ID_Tiny3.Value });
            int min = (int)Frame_min.Value;
            int max = (int)Frame_max.Value;
            IDFrames.Clear();
            IDFrames = new List<Frame_ID>();
            Frame_ID.correction = 0xFF;
            IDFilters idfilter = getIDFilter();
            for (int i = 0; i < min; i++)
                rng.Next();
            for (int i = min; i <= max; i++)
            {
                var result = new ID6(rng);
                if (!idfilter.CheckResult(result))
                    continue;
                IDFrames.Add(new Frame_ID(result, i));
            }
        }
        #endregion

        #region Gen7 Search
        private void Search7()
        {
            Frame_min.Value = Math.Max(Frame_min.Value, FuncUtil.getstartingframe(Gameversion.SelectedIndex, MainRNGEgg.Checked ? 0 : Method));
            // ID
            if (Method == 4)
            {
                Search7_ID();
                return;
            }
            // Eggs
            if (Method == 3 && !MainRNGEgg.Checked)
            {
                if (EggNumber.Checked)
                    Search7_EggList();
                else if (RB_EggShortest.Checked)
                    Search7_EggShortestPath();
                else
                    Search7_Egg();
                return;
            }
            // Method 0-2 & MainRNGEgg
            if (CreateTimeline.Checked)
                Search7_Timeline();
            else if (AroundTarget.Checked)
                Search7_AroundTarget();
            else if (RB_TimelineLeap.Checked)
                Search7_TimelineLeap();
            else
                Search7_Normal();
        }

        private void Search7_Normal()
        {
            SFMT sfmt = new SFMT(Seed.Value);
            int min = (int)Frame_min.Value;
            int max = (int)Frame_max.Value;
            if (min > max)
                return;
            // Blinkflag
            FuncUtil.getblinkflaglist(min, max, sfmt, Modelnum);
            // Advance
            for (int i = 0; i < min; i++)
                sfmt.Next();
            // Prepare
            ModelStatus status = new ModelStatus(Modelnum, sfmt);
            ModelStatus stmp = new ModelStatus(Modelnum, sfmt);
            status.raining = stmp.raining = Raining.Checked;
            getsetting(sfmt);
            int frameadvance;
            int realtime = 0;
            int frametime = 0;
            // Start
            for (int i = min; i <= max;)
            {
                do
                {
                    frameadvance = status.NextState();
                    realtime++;
                }
                while (frameadvance == 0); // Keep the starting status of a longlife frame(for npc=0 case)
                do
                {
                    RNGPool.CopyStatus(stmp);
                    var result = RNGPool.Generate7();

                    RNGPool.AddNext(sfmt);

                    frameadvance--;
                    i++;
                    if (i > max + 1)
                        continue;
                    byte blinkflag = FuncUtil.blinkflaglist[i - min - 1];
                    if (BlinkFOnly.Checked && blinkflag < 4)
                        continue;
                    if (SafeFOnly.Checked && blinkflag >= 2)
                        continue;
                    if (!filter.CheckResult(result))
                        continue;
                    Frames.Add(new Frame(result, frame: i - 1, time: frametime * 2, blink: blinkflag));
                }
                while (frameadvance > 0);

                if (Frames.Count > MAX_RESULTS_NUM)
                    return;
                // Backup current status
                status.CopyTo(stmp);
                frametime = realtime;
            }
        }

        private void Search7_AroundTarget()
        {
            SFMT sfmt = new SFMT(Seed.Value);
            int start = (int)Frame_min.Value;
            int target = (int)TargetFrame.Value;
            int min = target - 100;
            int max = target + 100;
            if (start > min)
                start = min;

            // Blinkflag
            FuncUtil.getblinkflaglist(min, max, sfmt, Modelnum);

            // Prepare
            int i = 0;
            byte blinkflag = 0;
            for (; i < start; i++)
                sfmt.Next();
            ModelStatus status = new ModelStatus(Modelnum, sfmt);
            ModelStatus stmp = new ModelStatus(Modelnum, sfmt);
            status.raining = stmp.raining = Raining.Checked;
            getsetting(sfmt);
            int frameadvance = 0;
            int realtime = 0;
            int frametime = 0;

            // Calc frames around target
            for (; i <= max;)
            {
                for (; frameadvance == 0; frameadvance = status.NextState())
                    realtime++;
                for (; frameadvance > 0; frameadvance--, i++)
                {
                    if (min <= i && i <= max)
                    {
                        RNGPool.CopyStatus(stmp);
                        var result = RNGPool.Generate7();
                        blinkflag = FuncUtil.blinkflaglist[i - min];
                        Frames.Add(new Frame(result, frame: i, time: frametime * 2, blink: blinkflag));
                    }
                    RNGPool.AddNext(sfmt);
                }

                // Backup current status
                status.CopyTo(stmp);
                frametime = realtime;
            }

            // Get all possible results by EC matching
            // Can't identify MainRNGEggs by EC
            if (Method < 3)
            {
                Frames = Frames.OrderBy(f => f.FrameNum + (f.rt as Result7).FrameDelayUsed).ToList();

                var EClist = Frames.Select(f => f.rt.EC).ToArray();

                // Another Buffer
                sfmt = new SFMT(Seed.Value);
                int starting = Frames[0].FrameNum + (Frames[0].rt as Result7).FrameDelayUsed;
                for (i = 0; i < starting; i++)
                    sfmt.Next();
                RNGPool.CreateBuffer(sfmt);

                // Skip Delay
                RNGPool.Considerdelay = false;
                if (RNGPool.igenerator is Stationary7 st7)
                    st7.AssumeSynced = Nature.CheckBoxItems[SyncNature.SelectedIndex].Checked;

                uint EC;
                uint EClast = EClist.Last();
                int Nframe = -1;
                ulong rand = 0;
                do
                {
                    RNGPool.modelnumber = Modelnum;
                    RNGPool.ResetModelStatus();
                    var result = RNGPool.Generate7() as Result7;
                    EC = result.EC;
                    RNGPool.AddNext(sfmt);
                    if (EClist.Contains(EC))
                    {
                        var framenow = Frames.LastOrDefault(f => f.EC == EC);
                        Nframe = framenow.FrameNum;
                        frametime = framenow.realtime;
                        rand = framenow.Rand64;
                        continue;
                    }
                    else if (Nframe > -1)
                    {
                        result.RandNum = rand;
                        Frames.Add(new Frame(result, frame: Nframe, time: frametime, blink: 4));
                    }
                }
                while (EC != EClast);
            }

            // Filters
            RNGResult.IsPokemon = true;
            Frames = Frames.Where(f => filter.CheckResult(f.rt))
                           .OrderBy(f => f.FrameNum)
                           .ToList();
        }

        private void Search7_Timeline()
        {
            if (gen7fishing)
            {
                Search7_FishyTimeline();
                return;
            }
            SFMT sfmt = new SFMT(Seed.Value);
            int start_frame = (int)Frame_min.Value;
            int targetframe = (int)TargetFrame.Value;
            FuncUtil.getblinkflaglist(start_frame, start_frame, sfmt, Modelnum);
            // Advance
            for (int i = 0; i < start_frame; i++)
                sfmt.Next();
            // Prepare
            ModelStatus status = new ModelStatus(Modelnum, sfmt) { IsBoy = Boy.Checked, raining = Raining.Checked };
            getsetting(sfmt);
            int totaltime = (int)TimeSpan.Value * 30;
            int frame = (int)Frame_min.Value;
            int frameadvance, Currentframe;
            int FirstJumpFrame = (int)JumpFrame.Value;
            FirstJumpFrame = FirstJumpFrame >= start_frame && gen7fidgettimeline ? FirstJumpFrame : int.MaxValue;
            // Start
            for (int i = 0; i <= totaltime; i++)
            {
                Currentframe = frame;

                RNGPool.CopyStatus(status);

                var result = RNGPool.Generate7();

                if (frame >= FirstJumpFrame) // Find the first call
                {
                    status.fidget_cd = XMenu.Checked ? 3 : 1;
                    FirstJumpFrame = int.MaxValue; // Disable this part
                }
                byte Jumpflag = (byte)(status.fidget_cd == 1 ? 1 : 0);
                frameadvance = status.NextState();
                frame += frameadvance;
                for (int j = 0; j < frameadvance; j++)
                    RNGPool.AddNext(sfmt);
                if (Currentframe <= targetframe && targetframe < frame)
                    Frame.standard = i * 2;

                if (!filter.CheckResult(result))
                    continue;

                Frames.Add(new Frame(result, frame: Currentframe, time: i * 2, blink: Jumpflag));

                if (Frames.Count > MAX_RESULTS_NUM)
                    break;
            }
            if (Frames.FirstOrDefault()?.FrameNum == (int)Frame_min.Value)
                Frames[0].Blink = FuncUtil.blinkflaglist[0];
        }

        private void Search7_FishyTimeline()
        {
            SFMT sfmt = new SFMT(Seed.Value);
            int start_frame = (int)Frame_min.Value;
            int targetframe = (int)TargetFrame.Value;
            // Advance
            for (int i = 0; i < start_frame; i++)
                sfmt.Next();
            // Prepare
            ModelStatus status = new ModelStatus(Modelnum, sfmt) { raining = Raining.Checked };
            getsetting(sfmt);
            int totaltime = (int)TimeSpan.Value * 30;
            int frameinput1 = (int)Frame_min.Value;          // Input 1: Cast the rod
            int frameadvance, fishingdelay, frameinput2;    // Input 2: Pull the rod off water
            var fsetting = getFishingSetting;
            int Timewindow = 2;

            // Start
            for (int i = 0; i <= totaltime; i++)
            {
                RNGPool.Save();

                // 2 Frames for delay calc
                // USUM v1.1 sub_39E2F0
                RNGPool.Rewind(0); RNGPool.CopyStatus(status);
                fishingdelay = (int)(RNGPool.getrand64 % 60) + fsetting.basedelay;
                if (Overview.Checked)
                    RNGPool.Advance(1); // Keep timewindow at 2 to avoid calculation
                else
                    Timewindow = (int)(RNGPool.getrand64 % 15) + fsetting.platdelay + 14;

                // Fishing Delay
                RNGPool.time_elapse7(fishingdelay);

                // Bitechance
                if (fsetting.suctioncups || (int)(RNGPool.getrand64 % 100) < 50)
                {
                    RNGPool.time_elapse7(1);
                    frameinput2 = RNGPool.index + frameinput1;
                    RNGPool.SaveStatus();

                    for (int j = 2; j <= Timewindow; j++)
                    {
                        RNGPool.LoadStatus();
                        RNGPool.time_elapse7(1);
                        frameinput2 += RNGPool.index;
                        RNGPool.SaveStatus();
                        RNGPool.DelayTime = fsetting.pkmdelay + Math.Max(0, fsetting.platdelay - j); //  Duplicates

                        var result = RNGPool.Generate7() as ResultW7;

                        if (!filter.CheckResult(result))
                            continue;
                        if (Overview.Checked)
                            result.RandNum = RNGPool.getsavepoint;
                        result.FrameDelayUsed += frameinput2 - frameinput1;
                        Frames.Add(new Frame(result, frame: frameinput2, time: (i + j + fishingdelay) * 2) { Frame0 = frameinput1 });
                    }
                }

                RNGPool.Load();

                if (Frames.Count > MAX_RESULTS_NUM)
                    break;

                // Move to next Frame, Update RNGPool
                frameadvance = status.NextState();
                frameinput1 += frameadvance;
                for (int j = 0; j < frameadvance; j++)
                    RNGPool.AddNext(sfmt);
            }
        }

        private void Search7_TimelineLeap()
        {
            int start = (int)Frame_min.Value;
            int target = (int)TargetFrame.Value;
            int Totaldelay = FuncUtil.CalcFrame(Seed.Value, start, target, Modelnum)[0];
            int mindelay = (int)Math.Round(DelayMin.Value * 30);
            int maxdelay = (int)Math.Round(DelayMax.Value * 30);
            int starttime = Totaldelay - maxdelay;
            int endtime = Totaldelay - mindelay;

            // Intialize
            SFMT sfmt = new SFMT(Seed.Value);
            for (int i = 0; i < start; i++)
                sfmt.Next();
            ModelStatus status = new ModelStatus(Modelnum, sfmt) { IsBoy = Boy.Checked };

            // Advance
            int frame = start;
            for (int i = 0; i < starttime; i++)
                frame += status.NextState();
            for (int i = start; i < frame; i++)
                sfmt.Next();

            getsetting(sfmt);

            List<int> Framelist = new List<int>();
            List<ModelStatus> statuslist = new List<ModelStatus>();
            List<int> timelist = new List<int>();

            // Search
            int LeapType = getLeapType();
            int frameadvance;
            int Tmpframe, bakframe1, bakframe2 = 0;
            ModelStatus stmp, bak1, bak2 = null;
            for (int i = Math.Max(0, starttime); i < endtime; i++)
            {
                Tmpframe = frame;
                stmp = status.Clone();

                // Leap!
                switch (LeapType)
                {
                    case 0: // WC7
                        for (int j = 0; j < 19; j++)
                            Tmpframe += stmp.NextState();
                        RNGPool.Rewind(Tmpframe - frame);
                        RNGPool.CopyStatus(stmp);
                        RNGPool.igenerator.Generate();
                        frameadvance = RNGPool.index - (Tmpframe - frame);
                        Tmpframe += stmp.frameshift(frameadvance);
                        Tmpframe += stmp.NextState();
                        break;
                    case 1: // Menu
                        stmp.fidget_cd = 3;
                        break;
                    case 2: // Dialogue
                        Tmpframe += stmp.NextState();
                        Tmpframe += stmp.NextState();
                        Tmpframe += stmp.frameshift(1);
                        Tmpframe += stmp.NextState();
                        break;
                }

                bak1 = stmp.Clone();
                bakframe1 = Tmpframe;

                // Check if hit
                while (Tmpframe < target)
                    Tmpframe += stmp.NextState();
                if (Tmpframe == target)
                {
                    Framelist.Add(frame);
                    timelist.Add(i);
                    bak2 = bak1.Clone();
                    bakframe2 = bakframe1;
                    statuslist.Add(stmp.Clone());
                }

                // Move to next state
                frameadvance = status.NextState();
                frame += frameadvance;
                for (int j = 0; j < frameadvance; j++)
                    RNGPool.AddNext(sfmt);
            }

            if (Framelist.Count > 0)
            {
                int frame0 = Framelist.Last();
                Frame_max.Value = frame0;
                if (!IsEvent) JumpFrame.Value = frame0;
                if (FormUtil.Prompt(MessageBoxButtons.YesNo, string.Format("Hit A at {0} (Frame1) and then at {1} (Frame2).\n\nYes: Check new timeline / No: Check the spread", frame0, target)) == DialogResult.Yes)
                {
                    Search7_TimelineLeap1(bakframe2, target, bak2, maxdelay);
                    foreach (var f in Frames) f.Frame0 = frame0;
                }
                else
                    Search7_TimelineLeap2(Framelist, statuslist, target, timelist);
            }
            else
                FormUtil.Error(StringItem.NORESULT_STR[StringItem.language]);
        }

        private void Search7_TimelineLeap1(int newstartframe, int targetframe, ModelStatus status, int totaltime)
        {
            // Prepare
            SFMT sfmt = new SFMT(Seed.Value);
            for (int i = 0; i < newstartframe; i++)
                sfmt.Next();
            getsetting(sfmt);
            int frame = newstartframe;
            int frameadvance, Currentframe;

            // Start
            for (int i = 0; i <= totaltime; i++)
            {
                Currentframe = frame;

                RNGPool.CopyStatus(status);

                var result = RNGPool.Generate7();

                byte Jumpflag = (byte)(status.fidget_cd == 1 ? 1 : 0);
                frameadvance = status.NextState();
                frame += frameadvance;
                for (int j = 0; j < frameadvance; j++)
                    RNGPool.AddNext(sfmt);
                if (Currentframe <= targetframe && targetframe < frame)
                    Frame.standard = i * 2;

                if (!filter.CheckResult(result))
                    continue;

                Frames.Add(new Frame(result, frame: Currentframe, time: i * 2, blink: Jumpflag));
            }
        }
        private void Search7_TimelineLeap2(List<int> framelist, List<ModelStatus> statuslist, int target, List<int> timelist)
        {
            // Prepare
            SFMT sfmt = new SFMT(Seed.Value);
            for (int i = 0; i < target; i++)
                sfmt.Next();
            getsetting(sfmt);
            Frame.standard = timelist.Last() * 2;

            // Start
            for (int i = 0; i < framelist.Count; i++)
            {
                RNGPool.CopyStatus(statuslist[i]);
                var result = RNGPool.Generate7();
                if (!filter.CheckResult(result))
                    continue;
                Frames.Add(new Frame(result, frame: target, time: timelist[i] * 2) { Frame0 = framelist[i] });
            }
        }

        private void Search7_Egg()
        {
            var rng = new TinyMT(Status);
            int min = (int)Frame_min.Value;
            int max = (int)Frame_max.Value;

            bool CheckRandomNumber(uint rn)
            {
                int sv = (int)Pokemon.getTSV(rn);
                return sv == TSV.Value || ConsiderOtherTSV.Checked && OtherTSVList.Contains(sv);
            }
            // Advance
            for (int i = 0; i < min; i++)
                rng.Next();
            // Prepare
            getsetting(rng);
            // Start
            for (int i = min; i <= max; i++, RNGPool.AddNext(rng))
            {
                var result = RNGPool.GenerateEgg7() as EggResult;
                if (!(filter.CheckResult(result) || ShinyRemind.Checked && CheckRandomNumber(result.RandNum)))
                    continue;
                Frames.Add(new Frame(result, frame: i));
                if (Frames.Count > MAX_RESULTS_NUM)
                    return;
            }
        }

        private void Search7_EggList()
        {
            var rng = new TinyMT(Status);
            int min = (int)Egg_min.Value - 1;
            int max = (int)Egg_max.Value - 1;
            int target = (int)TargetFrame.Value;
            bool gotresult = false;
            // Advance
            for (int i = 0; i < min; i++)
                rng.Next();
            TinyMT Seedrng = new TinyMT(rng.status);
            // Prepare
            getsetting(rng);
            // Start
            int frame = 0;
            int advance = 0;
            for (int i = 0; i <= max; i++)
            {
                var result = RNGPool.GenerateEgg7() as EggResult;
                advance = result.FramesUsed;
                if (!gotresult && frame <= target && target < frame + advance)
                {
                    Egg_Instruction.Text = getEggListString(i, target - frame);
                    gotresult = true;
                }
                frame += advance;
                for (int j = advance; j > 0; j--)
                    RNGPool.AddNext(rng);
                if (i < min || !filter.CheckResult(result))
                    continue;
                Frames.Add(new Frame(result, frame: frame - advance, eggnum: i + 1));
                if (Frames.Count > MAX_RESULTS_NUM)
                    break;
            }
            if (!gotresult)
                Egg_Instruction.Text = getEggListString(-1, -1);
        }

        private void Search7_EggShortestPath()
        {
            var rng = new TinyMT(Status);
            int max = (int)TargetFrame.Value;
            int rejectcount = 0;
            List<EggResult> ResultsList = new List<EggResult>();
            // Prepare
            getsetting(rng);
            // Start
            for (int i = 0; i <= max; i++, RNGPool.AddNext(rng))
                ResultsList.Add(RNGPool.GenerateEgg7() as EggResult);
            var FrameIndexList = Gen7EggPath.Calc(ResultsList.Select(egg => egg.FramesUsed).ToArray());
            max = FrameIndexList.Count;
            for (int i = 0; i < max; i++)
            {
                int index = FrameIndexList[i];
                var result = ResultsList[index];
                result.hiddenpower = (byte)Pokemon.getHiddenPowerValue(result.IVs);
                var Frame = new Frame(result, frame: index, eggnum: i + 1);
                if (i == max - 1 || FrameIndexList[i + 1] - index > 1)
                    Frame.FrameUsed = StringItem.EGGACCEPT_STR[lindex, 0];
                else
                {
                    Frame.FrameUsed = StringItem.EGGACCEPT_STR[lindex, 1];
                    rejectcount++;
                }
                Frames.Add(Frame);
            }
            Egg_Instruction.Text = getEggListString(max - rejectcount - 1, rejectcount, true);
        }

        private void Search7_ID()
        {
            SFMT rng = new SFMT(Seed.Value);
            int min = (int)Frame_min.Value;
            int max = (int)Frame_max.Value;
            IDFrames.Clear();
            IDFrames = new List<Frame_ID>();
            Frame_ID.correction = (byte)Clk_Correction.Value;
            IDFilters idfilter = getIDFilter();
            for (int i = 0; i < min; i++)
                rng.Next();
            for (int i = min; i <= max; i++)
            {
                var result = new ID7(rng.Nextulong());
                if (!idfilter.CheckResult(result))
                    continue;
                IDFrames.Add(new Frame_ID(result, i));
            }
        }
        #endregion
    }
}
