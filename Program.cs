using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace utimco
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0 || String.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("Please enter a json filename / filepath when running.");
                Console.WriteLine("Usage: dotnet run json1.json");
                return 1;
            }

            string filename = args[0];

            var jdata = File.ReadAllText(filename);
            var token = JToken.Parse(jdata);
            if (token is JArray)
            {
                foreach (JToken d in token)
                {
                    if (d is JObject)
                    {
                        UtimcoModel m = d.ToObject<UtimcoModel>();
                        var hi = m.HeaderItems;
                        if (hi.MenuItems.Count > 0)
                        {
                            Console.WriteLine(hi.TotalCount());
                        }
                    }
                }
            }

            return 0;
        }
    }
}
