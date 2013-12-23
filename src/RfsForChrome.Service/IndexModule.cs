using Nancy;

namespace RfsForChrome.Service
{
    public class IndexModule : NancyModule
    {
        public IndexModule(IFetchMajorIncidents fetchMajorIncidents)
        {
            Get["/"] = _ => View["Index"];
            Get["/fires"] = _ => Response.AsJson(fetchMajorIncidents.Fetch());
        }
    }
}