using Nancy;

namespace RfsForChrome.Service
{
    public class IndexModule : NancyModule
    {
        public IndexModule(IFetchMajorIncidents fetchMajorIncidents)
        {
            //Get["/"] = parameters =>
            //{
            //    return View["index"];
            //};

            Get["/fires"] = _ =>
            {
                return fetchMajorIncidents.Fetch();
            };
        }
    }
}