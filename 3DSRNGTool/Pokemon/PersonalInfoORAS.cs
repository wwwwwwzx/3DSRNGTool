using System;

namespace PKHeX.Core
{
    public class PersonalInfoORAS : PersonalInfo
    {
        public const int SIZE = 0x50;
        protected PersonalInfoORAS() { }
        public PersonalInfoORAS(byte[] data)
        {
            if (data.Length != SIZE)
                return;
            Data = data;
        }

        public override int HP => Data[0x00]; 
        public override int ATK => Data[0x01]; 
        public override int DEF => Data[0x02]; 
        public override int SPE => Data[0x03];
        public override int SPA => Data[0x04];
        public override int SPD => Data[0x05];
        public override int[] Types => new int[] { Data[0x06], Data[0x07] };
        public override int CatchRate  => Data[0x08];
        public override int Gender => Data[0x12]; 
        public override int[] Items => new int[] { BitConverter.ToInt16(Data, 0xC), BitConverter.ToInt16(Data, 0xE), BitConverter.ToInt16(Data, 0x10) };
        public override int[] EggGroups => new int[] { Data[0x16], Data[0x17] };
        public override int[] Abilities => new int[] { Data[0x18], Data[0x19], Data[0x1A] };
        public override byte EscapeRate => Data[0x1B];
        protected internal override int FormStatsIndex  => BitConverter.ToUInt16(Data, 0x1C);
        public override int FormeCount => Data[0x20];
    }
}
