using Ninject.Modules;

namespace RfsForChrome.Service
{
    public class MyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFetchMajorIncidents>().To<FetchMajorIncidents>().InSingletonScope();
        }
    }
}