using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace Pk3DSRNGTool
{
    public class Profiles
    {
        public ObservableCollection<Profile> GameProfiles = new ObservableCollection<Profile>();

        public class Profile
        {
            public int GameVersion { get; set; }
            public short TSV { get; set; }
            public bool ShinyChar { get; set; }
            public EggSeeds Seeds { get; set; }

        }

        public class EggSeeds
        {
            public uint Key3 { get; set; }
            public uint Key2 { get; set; }
            public uint Key1 { get; set; }
            public uint Key0 { get; set; }
        }

        public void ReadProfiles()
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

        public void WriteProfiles()
        {
            string file = Environment.CurrentDirectory + @"\profiles.xml";

            //GameProfiles.Add(new Profile() { GameVersion = 0, Seeds = new EggSeeds() { Key0 = 0, Key1 = 1, Key2 = 2, Key3 = 3 }, ShinyChar = true, TSV = 1234 });

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
