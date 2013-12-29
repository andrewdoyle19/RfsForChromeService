using System;
using System.Collections.Generic;
using System.Xml.Linq;
using RfsForChrome.Service.Models;

namespace RfsForChrome.Service
{
    public interface IFetchMajorIncidents
    {
        IEnumerable<Incident> Fetch();
    }
    
    public class FetchMajorIncidents : IFetchMajorIncidents
    {
        private readonly IOrderAndModelIncidents _orderIncidents;
        private readonly Uri _majorIncidentsUrl;

        public FetchMajorIncidents(IOrderAndModelIncidents orderIncidents, Uri majorIncidentsUrl)
        {
            _orderIncidents = orderIncidents;
            _majorIncidentsUrl = majorIncidentsUrl;

        }

        public IEnumerable<Incident> Fetch()
        {
            try
            {
                var document = XDocument.Load(_majorIncidentsUrl.ToString());
                return _orderIncidents.CreateModel(document);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Something went wrong :(", ex);    
            }
            
        }

    }
}