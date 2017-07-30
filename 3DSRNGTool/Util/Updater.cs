using System;
using System.Windows.Forms;
using static PKHeX.Util;

namespace Pk3DSRNGTool
{
    public static class Updater
    {
        public static void CheckUpdate()
        {
            if (TestInternet())
                TryDownload();
        }

        public static string CurrentVersion = "0.9.5";

        private static void TryDownload()
        {
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                //PlaceHolder
                string LatestVersion = "";

                try
                {
                    LatestVersion = wc.DownloadString("https://raw.githubusercontent.com/wwwwwwzx/3DSRNGTool/master/version.txt");
                    if (HasNewerVersion(LatestVersion, CurrentVersion))
                        if (Prompt(MessageBoxButtons.YesNo, "New version detected. Start to download?") == DialogResult.Yes)
                            System.Diagnostics.Process.Start("https://github.com/wwwwwwzx/3DSRNGTool/releases/download/" + LatestVersion + "/3DSRNGTool.exe", "3DSRNGTool.exe");
                }
                catch (Exception ex)
                {
                    Error("Please download manually as an error Occured:" + ex.Message);
                }
            }
        }

        private static bool HasNewerVersion(string Latest, string Current)
        {
            if (Latest == "" || Current == "")
                return false;
            return (new Version(Latest).CompareTo(new Version(Current)) > 0);
        }

        private static bool TestInternet()
        {
            try
            {
                var ping = new System.Net.NetworkInformation.Ping();
                ping.Send("github.com");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
