using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Pk3DSRNGTool
{
    public static class SFMTSeedAPI
    {
        public static List<Result> request(string needle, bool IsID, bool IsUltra)
        {
            Root root;
            var url = IsUltra ? $"https://rng-api.poyo.club/usm/sfmt/seed?needle={needle}" :
               ( IsID ? $"http://49.212.217.137:19937/gen7/sfmt/seed/id?needle={needle}" 
                           : $"http://49.212.217.137:19937/gen7/sfmt/seed?needle={needle}");
            string jsonStr;
            using (var webClient = new WebClient())
            {
                jsonStr = webClient.DownloadString(url);
            }

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonStr)))
            {
                var serializer = new DataContractJsonSerializer(typeof(Root));
                root = (Root)serializer.ReadObject(ms);
            }
            return root?.results;
        }

        public class Root
        {
            public List<Result> results { get; set; }
        }

        public class Result
        {
            public byte add { get; set; }
            public string seed { get; set; }
            public string encoded_needle { get; set; }
            public int step { get; set; }
        }
    }
}
