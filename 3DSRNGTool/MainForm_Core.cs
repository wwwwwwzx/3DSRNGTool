using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Pk3DSRNGTool.RNG;
using Pk3DSRNGTool.Core;
using static PKHeX.Util;

namespace Pk3DSRNGTool
{
    public partial class MainForm : Form
    {
        #region Gen6 Search
        private void Search6()
        {
            switch (Method)
            {
                case 0:
                    if (CreateTimeline.Checked) { Search6_Timeline(); return; }
                    goto default;
                case 2:
                    if (IsHorde) { Search6_Horde(); return; }
                    if (CreateTimeline.Checked) { Search6_Timeline(); return; }
                    goto default;
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
                if (Frames.Count > 100000)
                    break;
            }
        }

        private void Search6_Timeline()
        {
            if (!TTT.HasSeed)
            {
                Error("Please Calibrate Timeline");
                return;
            }
            var rng = new MersenneTwister(Seed.Value);
            int min = (int)Frame_min.Value;
            int max = (int)TimeSpan.Value * 60 + min;
            // Advance
            for (int i = 0; i < min; i++)
                rng.Next();
            // Prepare
            getsetting(rng);
            RNGPool.timeline = TTT.gettimeline();
            RNGPool.timeline.Maxframe = max;
            RNGPool.timeline.Generate(Method == 0); // Consider Stationary delay
            int listlength = RNGPool.timeline.TinyLength;
            for (int i = 0; i < listlength; i++)
            {
                var tinyframe = RNGPool.timeline.results[i];
                if (tinyframe.unhitable)
                    continue;
                if (tinyframe.framemax < min)
                    continue;
                for (int j = tinyframe.framemin + 2; j <= tinyframe.framemax; j += 2, RNGPool.AddNext(rng), RNGPool.AddNext(rng))
                {
                    while (j < min)
                        j += 2;
                    RNGPool.tinystatus = (TinyStatus)tinyframe.tinystate.DeepCopy();
                    RNGPool.tinystatus.Currentframe = j;
                    RNGResult result = RNGPool.Generate6();
                    if (!filter.CheckResult(result) || result is ResultW6 rt && !rt.IsPokemon)
                        continue;
                    Frames.Add(new Frame(result, frame: j, time: j - min));
                    Frames.Last()._tinystate = new PRNGState(tinyframe.state);
                    if (Frames.Count > 100000)
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
                RNGPool.horde = new HordeResults(new TinyMT(TTT.Gen6Tiny), (int)TTT.Parameters.Value);
                SlotSpecies.SelectedValue = slotspecies[RNGPool.horde.Slot - 1];
            }
            if (SlotSpecies.SelectedIndex > 0)
            {
                var Hordespecies = (ea as HordeArea).getSpecies(Ver, (byte)SlotSpecies.SelectedIndex);
                L_HordeInfo.Text = "Species: " + string.Join(" \t", Hordespecies.Select(t => StringItem.speciestr[t])) + "\n";
            }
            L_HordeInfo.Text += RNGPool.horde?.ToString() ?? "";
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
                if (Frames.Count > 500000)
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
            var eggnow = RNGPool.GenerateAnEgg6(key);
            eggnow.hiddenpower = (byte)Pokemon.getHiddenPowerValue(eggnow.IVs);
            if (RNGPool.IsMainRNGEgg) eggnow.PID = 0xFFFFFFFF;
            eggnow.Status = "Current";
            Frames.Add(new Frame(eggnow, frame: -1));

            // Start
            for (int i = min; i <= max; i++, RNGPool.AddNext(rng))
            {
                var result = RNGPool.GenerateEgg6();
                if (!filter.CheckResult(result))
                    continue;
                Frames.Add(new Frame(result, frame: i, time: i - min));
                if (Frames.Count > 100000)
                    return;
            }
        }

        private void Search6_ID()
        {
            var rng = new TinyMT(new uint[] { ID_Tiny0.Value, ID_Tiny1.Value, ID_Tiny2.Value, ID_Tiny3.Value });
            int min = Advanced.Checked ? 0 : (int)Frame_min.Value;
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
            Frame_min.Value = Math.Max(Frame_min.Value , FuncUtil.getstartingframe(Gameversion.SelectedIndex, MainRNGEgg.Checked ? 0 : Method));
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
            if (AroundTarget.Checked)
            {
                min = (int)TargetFrame.Value - 100; max = (int)TargetFrame.Value + 100;
            }
            // Blinkflag
            FuncUtil.getblinkflaglist(min, max, sfmt, Modelnum);
            // Advance
            for (int i = 0; i < min; i++)
                sfmt.Next();
            // Prepare
            ModelStatus status = new ModelStatus(Modelnum, sfmt);
            ModelStatus stmp = new ModelStatus(Modelnum, sfmt);
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
                    var result = RNGPool.Generate7() as Result7;

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

                if (Frames.Count > 100000)
                    return;
                // Backup current status
                status.CopyTo(stmp);
                frametime = realtime;
            }
        }

        private void Search7_Timeline()
        {
            SFMT sfmt = new SFMT(Seed.Value);
            int start_frame = (int)Frame_min.Value;
            int targetframe = (int)TargetFrame.Value;
            FuncUtil.getblinkflaglist(start_frame, start_frame, sfmt, Modelnum);
            // Advance
            for (int i = 0; i < start_frame; i++)
                sfmt.Next();
            // Prepare
            ModelStatus status = new ModelStatus(Modelnum, sfmt);
            status.IsBoy = Boy.Checked;
            getsetting(sfmt);
            int totaltime = (int)TimeSpan.Value * 30;
            int frame = (int)Frame_min.Value;
            int frameadvance, Currentframe;
            int FirstJumpFrame = (int)JumpFrame.Value;
            FirstJumpFrame = FirstJumpFrame >= start_frame && Fidget.Checked ? FirstJumpFrame : int.MaxValue;
            // Start
            for (int i = 0; i <= totaltime; i++)
            {
                Currentframe = frame;

                RNGPool.CopyStatus(status);

                var result = RNGPool.Generate7() as Result7;
                
                if (frame >= FirstJumpFrame) // Find the first call
                {
                    status.fidget_cd = 1;
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

                if (Frames.Count > 100000)
                    break;
            }
            if (Frames.FirstOrDefault()?.FrameNum == (int)Frame_min.Value)
                Frames[0].Blink = FuncUtil.blinkflaglist[0];
        }

        private void Search7_Egg()
        {
            var rng = new TinyMT(Status);
            int min = (int)Frame_min.Value;
            int max = (int)Frame_max.Value;
            // Advance
            for (int i = 0; i < min; i++)
                rng.Next();
            // Prepare
            getsetting(rng);
            // Start
            for (int i = min; i <= max; i++, RNGPool.AddNext(rng))
            {
                var result = RNGPool.GenerateEgg7() as EggResult;
                if (!filter.CheckResult(result))
                    continue;
                Frames.Add(new Frame(result, frame: i));
                if (Frames.Count > 100000)
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
            TinyMT Seedrng = (TinyMT)rng.DeepCopy();
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
                if (Frames.Count > 100000)
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
