using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using RfsForChrome.Service.Models;
using RfsForChrome.Service.Extensions;

namespace RfsForChrome.Service
{
    public interface IFetchMajorIncidents
    {
        IEnumerable<Incident> Fetch();
    }
    
    public class FetchMajorIncidents : IFetchMajorIncidents
    {
        private readonly string _majorIncidentsUrl;

        public FetchMajorIncidents()
        {
            _majorIncidentsUrl = ConfigurationManager.AppSettings["MajorIncidentsUrl"];
        }

        public IEnumerable<Incident> Fetch()
        {
            var document = XDocument.Load(_majorIncidentsUrl);

            var items = document.Descendants("item");
            
            var test = items.Select(s => new Incident()
                {
                    Title = s.Element("title").Value,
                    Link = s.Element("link").Value,
                    Category = s.Element("category").Value,
                    LastUpdated = s.Element("pubDate").Value.MyToDateTime()
                });
            
            
            
            return test.Take(10);
        }

        

        private Category GetCategory(string value)
        {
            switch (value)
            {
                case "Emergency Warning": 
                    return Category.EmergencyWarning;
                case "Watch and Act" : 
                    return Category.WatchAndAct;
                case "Advice" : 
                    return Category.Advice;
                default:
                    return Category.NotApplicable;
            }
        }
    }
}