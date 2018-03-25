using System.Linq;

namespace Pk3DSRNGTool
{
    public class Frame_Tiny
    {
        public static int Startingframe;
        public static byte thershold;
        public int Index { get; set; }
        public int hit = -1;
        public int HitIndex { get => hit == -1 ? Index : hit; set => hit = value; }
        public bool? sync;
        public byte? slot;
        public byte enctr;
        public uint[] state;
        public uint rand;
        public int framemin;
        public int framemax;
        public TinyStatus tinystate;
        public HordeResults horde;
        public byte Flute { get; set; }
        public byte item;

        public bool unhitable => framemin == framemax;
        public bool rand2 => rand < 0x80000000;

        public string Status => string.Join(",", state.Select(v => v.ToString("X8")).Reverse());
        public char Sync => sync ?? horde?.Sync ?? rand < 0x80000000 ? 'O' : 'X';
        public string Encounter => enctr < thershold || thershold == 1 ? enctr.ToString() : "X";
        public string HA => horde == null || horde.HA == 0 ? "-" : horde.HA.ToString();
        public string Item => horde == null ? StringItem.helditemStr[item] : horde.ItemString;

        public byte Rand100 => (byte)((rand * 100ul) >> 32);
        public ushort High16bit => (ushort)(rand >> 16);
        public string FrameRange => framemin == framemax ? "-" : $"{framemin + 2}~{framemax} ({framemax - framemin})";
        public string RealTime => framemin == framemax ? "-" : FuncUtil.Convert2timestr((framemin + 2 - Startingframe) / 60.0) + " ~ " + FuncUtil.Convert2timestr((framemax - Startingframe) / 60.0);
        public byte Slot
        {
            get
            {
                if (slot != null)
                    return (byte)slot;
                if (horde != null)
                    return horde.Slot;
                return Core.WildRNG.getSlot((int)rand, 2);
            }
        }
    }
}
