using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RfsForChrome.Service
{
    public interface IFetchMajorIncidents
    {
        string Fetch();
    }
    
    public class FetchMajorIncidents : IFetchMajorIncidents
    {
        public string Fetch()
        {
            return "All Fires";
        }
    }
}