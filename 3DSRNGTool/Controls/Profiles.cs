using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using static Pk3DSRNGTool.StringItem;

namespace Pk3DSRNGTool
{
    public static class Profiles
    {
        public static BindingList<Profile> GameProfiles = new BindingList<Profile>();

        public class Profile : INotifyPropertyChanged
        {
            private string _Description;
            public string Description
            {
                get { return _Description; }
                set
                {
                    if (_Description != value)
                    {
                        _Description = value;
                        NotifyChanged("Description");
                    }
                }
            }

            private int _GameVersion;
            [Browsable(false)]
            public int GameVersion
            {
                get { return _GameVersion; }
                set
                {
                    if (_GameVersion != value)
                    {
                        _GameVersion = value;
                        NotifyChanged("GameVersion");
                    }
                }
            }

            [DisplayName("Game")]
            public string ShowGameVersion
            {
                get
                {
                    return GAMEVERSION_STR[language, GameVersion];
                }
            }

            private ushort _TSV;
            public ushort TSV
            {
                get { return _TSV; }
                set
                {
                    if (_TSV != value)
                    {
                        _TSV = value;
                        NotifyChanged("TSV");
                    }
                }
            }

            private ushort _TRV;
            public ushort TRV
            {
                get { return _TRV; }
                set
                {
                    if (_TRV != value)
                    {
                        _TRV = value;
                        NotifyChanged("TRV");
                    }
                }
            }

            private bool _ShinyCharm;
            [DisplayName("Shiny Charm?")]
            public bool ShinyCharm
            {
                get { return _ShinyCharm; }
                set
                {
                    if (_ShinyCharm != value)
                    {
                        _ShinyCharm = value;
                        NotifyChanged("ShinyCharm");
                    }
                }
            }

            private uint[] _Seeds = new uint[4];
            [Browsable(false)]
            public uint[] Seeds
            {
                get { return _Seeds; }
                set
                {
                    if (!_Seeds.SequenceEqual(value))
                    {
                        _Seeds = (uint[])value.Clone();
                        NotifyChanged("Seeds");
                    }
                }
            }

            [DisplayName("Egg Seeds")]
            public string ShowSeeds
            {
                get
                {
                    return GameVersion > 4 ? string.Join(",", Seeds.Select(v => v.ToString("X8")).Reverse())
                        : string.Join(",", Seeds.Take(2).Select(v => v.ToString("X8")).Reverse());
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static void ReadProfiles()
        {
            string file = Environment.CurrentDirectory + @"\profiles_3dsrngtool.xml";
            bool WriteNew = !File.Exists(file);

            if (WriteNew)
                file = Environment.CurrentDirectory + @"\profiles.xml"; // try the old format

            if (File.Exists(file))
            {
                try
                {
                    XmlSerializer xmlDeserializer = new XmlSerializer(typeof(BindingList<Profile>));
                    using (TextReader txtReader = new StreamReader(file))
                    {
                        GameProfiles = (BindingList<Profile>)xmlDeserializer.Deserialize(txtReader);
                    }
                    GameProfiles = new BindingList<Profile>(GameProfiles.Where(t => t != null && !string.IsNullOrEmpty(t.Description)).ToList()); // Remove empty entry
                    if (WriteNew && GameProfiles.Count > 0)
                        WriteProfiles();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Reading profile(s) failed: " + ex.Message);
                }
            }
        }

        public static void WriteProfiles()
        {
            string file = Environment.CurrentDirectory + @"\profiles_3dsrngtool.xml";

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(BindingList<Profile>));
                using (TextWriter txtWriter = new StreamWriter(file))
                {
                    xmlSerializer.Serialize(txtWriter, GameProfiles);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Writing profile(s) failed: " + ex.Message);
            }
        }
    }
}
