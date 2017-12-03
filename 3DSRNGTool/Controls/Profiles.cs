using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

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
                    switch (GameVersion)
                    {
                        case 0:
                            return "X";
                        case 1:
                            return "Y";
                        case 2:
                            return "OR";
                        case 3:
                            return "AS";
                        case 4:
                            return "Transporter";
                        case 5:
                            return "Sun";
                        case 6:
                            return "Moon";
                        case 7:
                            return "Ultra Sun";
                        case 8:
                        default:
                            return "Ultra Moon";
                    }
                }
            }

            private short _TSV;
            public short TSV
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

            private EggSeeds _Seeds;
            [Browsable(false)]
            public EggSeeds Seeds
            {
                get { return _Seeds; }
                set
                {
                    if (_Seeds != value)
                    {
                        _Seeds = value;
                        NotifyChanged("Seeds");
                    }
                }
            }

            [DisplayName("Egg Seeds")]
            public string ShowSeeds
            {
                get
                {
                    string seeds = string.Empty;
                    seeds += (Seeds.Key0 != 0 ? Seeds.Key0.ToString() + " - " : ""); //Improve :)
                    seeds += (Seeds.Key1 != 0 ? Seeds.Key1.ToString() + " - " : "");
                    seeds += (Seeds.Key2 != 0 ? Seeds.Key2.ToString() + " - " : "");
                    seeds += (Seeds.Key3 != 0 ? Seeds.Key3.ToString() : "");

                    return seeds;
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public class EggSeeds
        {
            public uint Key3 { get; set; }
            public uint Key2 { get; set; }
            public uint Key1 { get; set; }
            public uint Key0 { get; set; }
        }

        public static void ReadProfiles()
        {
            string file = Environment.CurrentDirectory + @"\profiles.xml";

            if (File.Exists(file))
            {
                try
                {
                    XmlSerializer xmlDeserializer = new XmlSerializer(typeof(ObservableCollection<Profile>));
                    using (TextReader txtReader = new StreamReader(file))
                    {
                        GameProfiles = (BindingList<Profile>)xmlDeserializer.Deserialize(txtReader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Reading profile(s) failed: " + ex.Message);
                }
            }
        }

        public static void WriteProfiles()
        {
            string file = Environment.CurrentDirectory + @"\profiles.xml";

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
