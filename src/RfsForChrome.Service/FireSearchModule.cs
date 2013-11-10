using Ninject.Modules;

namespace RfsForChrome.Service
{
    public class FireSearchModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFetchMajorIncidents>().To<FetchMajorIncidents>().InSingletonScope();
        }
    }
}