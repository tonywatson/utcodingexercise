using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace utimco
{
    class Program
    {
        static void Main(string[] args)
        {
            var jdata = File.ReadAllText("json1.json");
            var token = JToken.Parse(jdata);
            if (token is JArray)
            {
                foreach (JToken d in token)
                {
                    if (d is JObject)
                    {
                        UtimcoModel m = d.ToObject<UtimcoModel>();
                        var hi = m.HeaderItems;
                        if (hi.MenuItems.Count > 0) {
                            Console.WriteLine(hi.TotalCount());
                        }
                    }
                }
            }
        }
    }
}
