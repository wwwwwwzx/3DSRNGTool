using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Pk3DSRNGTool
{
    public partial class NtrClient
    {
        // Rosalina InputRedirection
        public Socket socket;
        public void CheckSocket()
        {
            if (socket == null)
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0);
            if (!socket.Connected)
            {
                socket.Connect(host, 4950);
            }
        }
        private readonly byte[] EmptyData = { 0xFF, 0x0F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x08, 0x80, 0x00 };
        private const uint ButtonOff = 0x10DF20;
        private const ushort noKey = 0xFFF;
        private const ushort keyA = 0xFFE;
        private const ushort keyB = 0xFFD;
        private const ushort keyStart = 0xFF7;

        private const uint TouchscrOff = 0x10DF24;
        private const uint touchEnter_U = 0x01707C70;
        private const uint touchEnter_J = 0x01E30D60;
        private const uint noTouch = 0x02000000;

        private int Buttondelay => 200;

        private void SendButtonMsg(ushort key)
        {
            try
            {
                // Try NTR first
                Write(ButtonOff, BitConverter.GetBytes(key), 0x10);
            }
            catch
            {
                if (socket.Connected)
                {
                    var data = (byte[])EmptyData.Clone();
                    BitConverter.GetBytes(key).CopyTo(data, 0);
                    socket.Send(data);
                }
            }
        }

        private void SendTouchMsg(uint TouchCoord)
        {
            try
            {
                // Try NTR first
                Write(TouchscrOff, BitConverter.GetBytes(TouchCoord), 0x10);
            }
            catch
            {
                if (socket.Connected)
                {
                    var data = (byte[])EmptyData.Clone();
                    BitConverter.GetBytes(TouchCoord).CopyTo(data, 4);
                    socket.Send(data);
                }
            }
        }

        public async void QuickButton(ushort key)
        {
            SendButtonMsg(key);
            await Task.Delay(Buttondelay);
            SendButtonMsg(noKey);
        }

        public async void QuickTouch(uint TouchCoord)
        {
            SendTouchMsg(TouchCoord);
            await Task.Delay(Buttondelay);
            SendTouchMsg(noTouch);
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
        public void PressStart() => QuickButton(keyStart);
        public void Confirm(bool JP) => QuickTouch(JP ? touchEnter_J : touchEnter_U);
    }
}