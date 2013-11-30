using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RfsForChrome.Service.Models
{
    public class Incident
    {
        public string Title { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Category Category { get; set; }

        public string Link { get; set; }

        public DateTime LastUpdated { get; set; }

        public string CouncilArea { get; set; }

        public string Status { get; set; }

        public string Size { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }
    }
}