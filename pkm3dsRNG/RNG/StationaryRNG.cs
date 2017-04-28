﻿using System.Collections.Generic;
using System.Linq;

namespace pkm3dsRNG.RNG
{
    class StationaryRNG
    {
        // Background Info (Global variables)
        public bool AlwaysSync;
        public byte Synchro_Stat;
        public bool IV3;
        public int TSV;
        public bool IsShinyLocked;
        public bool ShinyCharm;

        public byte Level;
        public byte Gender;
        public bool RandomGender;
        public byte Ability;
        public int[] IVs;

        private static uint getrand => RNGPool.getrand;

        // Generated Attributes
        public int PerfectIVCount => IV3 ? 3 : 0;
        public int PIDroll_count => ShinyCharm && !IsShinyLocked ? 3 : 1;

        public RNGResult Generate()
        {
            RNGResult rt = new RNGResult();
            rt.Level = Level;

            //Sync
            if (AlwaysSync)
                rt.Synchronize = true;
            else
                rt.Synchronize = (int)(getrand % 100) >= 50;

            rt.Synchronize &= Synchro_Stat < 25;

            //Encryption Constant
            rt.EC = getrand;

            //PID
            for (int i = 0; i < PIDroll_count; i++)
            {
                rt.PID = getrand;
                if (rt.PSV == TSV)
                    break;
            }
            if (IsShinyLocked && rt.PSV == TSV)
                rt.PID ^= 0x10000000;
            rt.Shiny = rt.PSV == TSV;

            //IV
            rt.IVs = (int[])IVs?.Clone() ?? new[] { -1, -1, -1, -1, -1, -1 };
            while (rt.IVs.Count(iv => iv == 31) < PerfectIVCount)
                rt.IVs[(int)(getrand % 6)] = 31;
            for (int i = 0; i < 6; i++)
                if (rt.IVs[i] < 0)
                    rt.IVs[i] = (int)(getrand & 0x1F);

            //Nature
            rt.Nature = (byte)(rt.Synchronize ? Synchro_Stat : getrand % 25);

            //Gender
            rt.Gender = (byte)(RandomGender ? ((int)(getrand % 252) >= Gender ? 1 : 2) : Gender);

            return rt;
        }

        public void UseTemplate(Pokemon PM)
        {
            AlwaysSync = PM.AlwaysSync;
            IV3 = PM.IV3;
            IsShinyLocked = PM.ShinyLocked;
            Ability = PM.Ability;
            IVs = PM.IVs;
            Level = PM.Level;
            Gender = PM.SettingGender;
            RandomGender = PM.IsRandomGender;
            if (PM.Nature < 25)
                Synchro_Stat = PM.Nature;
        }
    }
}