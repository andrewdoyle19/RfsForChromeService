using Nancy;

namespace RfsForChrome.Service
{
    public class IndexModule : NancyModule
    {
        public IndexModule(IFetchMajorIncidents fetchMajorIncidents)
        {
            Get["/fires"] = _ => Response.AsJson(fetchMajorIncidents.Fetch());
            
        }
    }
}