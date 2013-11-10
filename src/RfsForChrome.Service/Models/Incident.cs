using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RfsForChrome.Service.Models
{
    public class Incident
    {
        public string Title { get; set; }

        public string Category { get; set; }

        public string Link { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}