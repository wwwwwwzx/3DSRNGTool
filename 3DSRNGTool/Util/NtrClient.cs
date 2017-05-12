using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Pk3DSRNGTool
{
    public class NtrClient
    {
        public string host;
        public int port;
        public TcpClient tcp;
        public NetworkStream netStream;
        public Thread packetRecvThread;
        private object syncLock = new object();
        private bool heartbeatSendable;

        public delegate void logHandler(string msg);
        public event logHandler onLogArrival;
        uint currentSeq;
        uint lastReadMemSeq;
        string lastReadMemFileName = null;
        public volatile int progress = -1;

        public event EventHandler<InfoReadyEventArgs> InfoReady;

        protected virtual void OnInfoReady(InfoReadyEventArgs e)
        {
            InfoReady?.Invoke(this, e);
        }

        #region Interface
        public uint Seed { get; private set; }
        public bool NewResult;
        public void bpadd(uint addr, string type = "code.once")
        {
            switch (type)
            {
                case "code":
                    sendEmptyPacket(11, 1, addr, 1);
                    return;
                case "code.once":
                    sendEmptyPacket(11, 2, addr, 1);
                    return;
            }
        }

        public void resume()
        {
            sendEmptyPacket(11, 0, 0, 4);
        }

        public void Read(uint addr, uint size = 4, int pid = -1)
        {
            if (size > 1024) size = 1024;
            sendReadMemPacket(addr, size, (uint)pid);
        }

        public void Write(uint addr, byte[] buf, int pid = -1)
        {
            sendWriteMemPacket(addr, (uint)pid, buf);
        }

        public void setServer(string serverHost, int serverPort)
        {
            host = serverHost;
            port = serverPort;
        }

        public void connectToServer()
        {
            if (tcp != null)
            {
                disconnect();
            }
            tcp = new TcpClient();
            tcp.NoDelay = true;
            tcp.Connect(host, port);
            currentSeq = 0;
            netStream = tcp.GetStream();
            heartbeatSendable = true;
            packetRecvThread = new Thread(new ThreadStart(packetRecvThreadStart));
            packetRecvThread.Start();
            log("Server connected.");
        }

        public void disconnect(bool waitPacketThread = true)
        {
            try
            {
                if (tcp != null)
                {
                    tcp.Close();
                }
                if (waitPacketThread)
                {
                    if (packetRecvThread != null)
                    {
                        packetRecvThread.Join();
                    }
                }
            }
            catch (Exception ex)
            {
                log(ex.Message);
            }
            tcp = null;
        }

        public void listprocess()
        {
            sendEmptyPacket(5);
        }
        #endregion

        private int readNetworkStream(NetworkStream stream, byte[] buf, int length)
        {
            int index = 0;
            bool useProgress = false;

            if (length > 100000)
            {
                useProgress = true;
            }
            do
            {
                if (useProgress)
                {
                    progress = (int)(((double)(index) / length) * 100);
                }
                int len = stream.Read(buf, index, length - index);
                if (len == 0)
                {
                    return 0;
                }
                index += len;
            } while (index < length);
            progress = -1;
            return length;
        }

        private void packetRecvThreadStart()
        {
            byte[] buf = new byte[84];
            uint[] args = new uint[16];
            int ret;
            NetworkStream stream = netStream;

            while (true)
            {
                try
                {
                    ret = readNetworkStream(stream, buf, buf.Length);
                    if (ret == 0)
                    {
                        break;
                    }
                    int t = 0;
                    uint magic = BitConverter.ToUInt32(buf, t);
                    t += 4;
                    uint seq = BitConverter.ToUInt32(buf, t);
                    t += 4;
                    uint type = BitConverter.ToUInt32(buf, t);
                    t += 4;
                    uint cmd = BitConverter.ToUInt32(buf, t);
                    for (int i = 0; i < args.Length; i++)
                    {
                        t += 4;
                        args[i] = BitConverter.ToUInt32(buf, t);
                    }
                    t += 4;
                    uint dataLen = BitConverter.ToUInt32(buf, t);
                    if (cmd != 0)
                    {
                        log(string.Format("packet: cmd = {0}, dataLen = {1}", cmd, dataLen));
                    }

                    if (magic != 0x12345678)
                    {
                        log(string.Format("broken protocol: magic = {0}, seq = {1}", magic, seq));
                        break;
                    }

                    if (cmd == 0)
                    {
                        if (dataLen != 0)
                        {
                            byte[] dataBuf = new byte[dataLen];
                            readNetworkStream(stream, dataBuf, dataBuf.Length);
                            string logMsg = Encoding.UTF8.GetString(dataBuf);
                            OnInfoReady(new InfoReadyEventArgs(logMsg));
                            log(logMsg);
                        }
                        lock (syncLock)
                        {
                            heartbeatSendable = true;
                        }
                        continue;
                    }
                    if (dataLen != 0)
                    {
                        byte[] dataBuf = new byte[dataLen];
                        readNetworkStream(stream, dataBuf, dataBuf.Length);
                        handlePacket(cmd, seq, dataBuf);
                    }
                }
                catch (Exception e)
                {
                    log(e.Message);
                    break;
                }
            }

            log("Server disconnected.");
            disconnect(false);
        }

        private string byteToHex(byte[] datBuf, int type)
        {
            string r = "";
            for (int i = 0; i < datBuf.Length; i++)
            {
                r += datBuf[i].ToString("X2") + " ";
            }
            return r;
        }

        private void byteToSeed(byte[] datBuf)
        {
            Seed = BitConverter.ToUInt32(datBuf, 0);
            NewResult = true;
        }

        private void handleReadMem(uint seq, byte[] dataBuf)
        {
            if (seq != lastReadMemSeq)
            {
                log("seq != lastReadMemSeq, ignored");
                return;
            }
            lastReadMemSeq = 0;
            string fileName = lastReadMemFileName;
            if (fileName != null)
            {
                FileStream fs = new FileStream(fileName, FileMode.Create);
                fs.Write(dataBuf, 0, dataBuf.Length);
                fs.Close();
                log("dump saved into " + fileName + " successfully");
                return;
            }
            if (dataBuf.Length == 4)
                byteToSeed(dataBuf);
            log(byteToHex(dataBuf, 0));
        }

        private void handlePacket(uint cmd, uint seq, byte[] dataBuf)
        {
            if (cmd == 9)
                handleReadMem(seq, dataBuf);
        }

        private void sendPacket(uint type, uint cmd, uint[] args, uint dataLen)
        {
            int t = 0;
            currentSeq += 1000;
            byte[] buf = new byte[84];
            BitConverter.GetBytes(0x12345678).CopyTo(buf, t);
            t += 4;
            BitConverter.GetBytes(currentSeq).CopyTo(buf, t);
            t += 4;
            BitConverter.GetBytes(type).CopyTo(buf, t);
            t += 4;
            BitConverter.GetBytes(cmd).CopyTo(buf, t);
            for (int i = 0; i < 16; i++)
            {
                t += 4;
                uint arg = 0;
                if (args != null)
                {
                    arg = args[i];
                }
                BitConverter.GetBytes(arg).CopyTo(buf, t);
            }
            t += 4;
            BitConverter.GetBytes(dataLen).CopyTo(buf, t);
            netStream.Write(buf, 0, buf.Length);
        }

        private void sendReadMemPacket(uint addr, uint size, uint pid, string fileName = null)
        {
            sendEmptyPacket(9, pid, addr, size);
            lastReadMemSeq = currentSeq;
            lastReadMemFileName = fileName;
        }

        private void sendWriteMemPacket(uint addr, uint pid, byte[] buf)
        {
            uint[] args = new uint[16];
            args[0] = pid;
            args[1] = addr;
            args[2] = (uint)buf.Length;
            sendPacket(1, 10, args, args[2]);
            netStream.Write(buf, 0, buf.Length);
        }

        private void sendHeartbeatPacket()
        {
            if (tcp != null)
            {
                lock (syncLock)
                {
                    if (heartbeatSendable)
                    {
                        heartbeatSendable = false;
                        sendPacket(0, 0, null, 0);
                    }
                }
            }
        }

        private void sendEmptyPacket(uint cmd, uint arg0 = 0, uint arg1 = 0, uint arg2 = 0)
        {
            uint[] args = new uint[16];

            args[0] = arg0;
            args[1] = arg1;
            args[2] = arg2;
            sendPacket(0, cmd, args, 0);
        }

        private void sendSaveFilePacket(string fileName, byte[] fileData)
        {
            byte[] fileNameBuf = new byte[0x200];
            Encoding.UTF8.GetBytes(fileName).CopyTo(fileNameBuf, 0);
            sendPacket(1, 1, null, (uint)(fileNameBuf.Length + fileData.Length));
            netStream.Write(fileNameBuf, 0, fileNameBuf.Length);
            netStream.Write(fileData, 0, fileData.Length);
        }

        private void log(string msg)
        {
            if (onLogArrival != null)
            {
                onLogArrival.Invoke(msg);
            }
            try
            {
                Console.WriteLine(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class InfoReadyEventArgs : EventArgs
    {
        public string info;

        public InfoReadyEventArgs(string info_)
        {
            this.info = info_;
        }
    }
}
