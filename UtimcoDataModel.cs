using System.Collections.Generic;
using Newtonsoft.Json;

namespace utimco
{
    public class UtimcoModel
    {
        [JsonProperty(propertyName: "menu")]
        public MenuHeaderItem HeaderItems { get; set; }
    }

    public class MenuHeaderItem
    {
        [JsonProperty(propertyName: "header")]
        public string Header { get; set; }
        [JsonProperty(propertyName: "items")]
        public List<MenuItem> MenuItems { get; set; }
        public int TotalCount()
        {
            int total = 0;
            foreach (MenuItem mi in MenuItems)
            {
                if (mi != null && mi.Label != null)
                {
                    total += mi.Id;
                }
            }
            return total;
        }
    }

    public class MenuItem
    {
        [JsonProperty(propertyName: "id")]
        public int Id { get; set; }
        [JsonProperty(propertyName: "label")]
        public string Label { get; set; }
    }
}