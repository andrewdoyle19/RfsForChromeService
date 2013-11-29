using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using RfsForChrome.Service.Extensions;
using RfsForChrome.Service.Models;

namespace RfsForChrome.Service
{
    public interface IOrderAndModelIncidents
    {
        IEnumerable<Incident> CreateModel(XDocument document);
    }

    public class OrderAndModelIncidents : IOrderAndModelIncidents
    {
        public IEnumerable<Incident> CreateModel(XDocument document)
        {
            var items = document.Descendants("item");

            var incidents = items.Select(s => new Incident()
            {
                Title = s.Element("title").Value,
                Link = s.Element("link").Value,
                Category = GetCategory(s.Element("category").Value),
                LastUpdated = s.Element("pubDate").Value.MyToDateTime(), //TODO: This is wrong, should use data from Description
                CouncilArea = ParseItemFromDescriptionString(s.Element("description").Value, "COUNCIL AREA"),
                Status = ParseItemFromDescriptionString(s.Element("description").Value, "STATUS"),
                Size = ParseItemFromDescriptionString(s.Element("description").Value, "SIZE")

            });
            

            return incidents;
        }

        private string ParseItemFromDescriptionString(string value, string item)
        {
            var trimmed = value.Trim();
            string regex = string.Format("<br />{0}: (.*?)<br />",item);
            return Regex.Split(trimmed, regex).ElementAt(1).Trim();
        }

        private Category GetCategory(string value)
        {
            switch (value)
            {
                case "Emergency Warning":
                    return Category.EmergencyWarning;
                case "Watch and Act":
                    return Category.WatchAndAct;
                case "Advice":
                    return Category.Advice;
                default:
                    return Category.NotApplicable;
            }
        }
    }
}