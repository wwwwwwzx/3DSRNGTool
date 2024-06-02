using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Pk3DSRNGTool
{
    public static class SFMTSeedAPI
    {
        public static List<Result> request(string needle, bool IsID, bool IsUltra)
        {
            var url = $"https://rng-api.odanado.com{(IsUltra ? "/usm" : "/sm")}/sfmt/seed{(IsID ? "/id" : string.Empty)}?needle={needle}";

            using var httpClient = new HttpClient();
            var response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            string jsonStr = response.Content.ReadAsStringAsync().Result;

            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonStr));
            var serializer = new DataContractJsonSerializer(typeof(Root));
            var root = (Root)serializer.ReadObject(ms);

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
