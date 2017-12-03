using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace Pk3DSRNGTool
{
    public static class Profiles
    {
        public static ObservableCollection<Profile> GameProfiles = new ObservableCollection<Profile>();

        public class Profile
        {
            public string Description { get; set; }

            [System.ComponentModel.Browsable(false)]
            public int GameVersion { get; set; }

            [System.ComponentModel.DisplayName("Game")]
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

            public short TSV { get; set; }

            [System.ComponentModel.DisplayName("Shiny Charm?")]
            public bool ShinyCharm { get; set; }

            [System.ComponentModel.Browsable(false)]
            public EggSeeds Seeds { get; set; }

            [System.ComponentModel.DisplayName("Egg Seeds")]
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
                        GameProfiles = (ObservableCollection<Profile>)xmlDeserializer.Deserialize(txtReader);
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



            GameProfiles.Add(new Profile() { Description = "Testing", GameVersion = 0, Seeds = new EggSeeds() { Key0 = 0, Key1 = 1, Key2 = 2, Key3 = 3 }, ShinyCharm = true, TSV = 1234 });

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Profile>));
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
