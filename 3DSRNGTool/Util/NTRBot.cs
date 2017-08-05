using System;
using System.Threading.Tasks;

namespace Pk3DSRNGTool
{
    public partial class NtrClient
    {
        private const uint ButtonOff = 0x10DF20;
        private const ushort noKey = 0xFFF;
        private const ushort keyA = 0xFFE;
        private const ushort keyB = 0xFFD;

        private const uint TouchscrOff = 0x10DF24;
        private const uint touchEnter = 0x01707C70;
        private const uint noTouch = 0x02000000;

        private int Buttondelay => Gameversion < 4 ? 200 : 100;
        public async void QuickButton(ushort key)
        {
            Write(ButtonOff, BitConverter.GetBytes(key), 0x10);
            await Task.Delay(Buttondelay);
            Write(ButtonOff, BitConverter.GetBytes(noKey), 0x10);
        }

        public async void QuickTouch(uint TouchCoord)
        {
            Write(TouchscrOff, BitConverter.GetBytes(TouchCoord), 0x10);
            await Task.Delay(Buttondelay);
            Write(TouchscrOff, BitConverter.GetBytes(noTouch), 0x10);
        }

        private uint getHexCoord(decimal Xvalue, decimal Yvalue)
        {
            uint hexX = Convert.ToUInt32(Math.Round(Xvalue * 0xFFF / 319));
            uint hexY = Convert.ToUInt32(Math.Round(Yvalue * 0xFFF / 239));
            return 0x01000000 + hexY * 0x1000 + hexX;
        }

        public void QuickTouch(decimal X, decimal Y) => QuickTouch(getHexCoord(X, Y));
        public void PressA() => QuickButton(keyA);
        public void PressB() => QuickButton(keyB);
        public void Confirm() => QuickTouch(touchEnter);
    }
}