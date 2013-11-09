using Nancy;
using Nancy.Bootstrappers.Ninject;
using Ninject;
using Ninject.Modules;

namespace RfsForChrome.Service
{
    public class Bootstrapper : NinjectNancyBootstrapper 
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
        
        protected override void ApplicationStartup(IKernel container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            container.Load<MyModule>();
        }
         
    }

    public class MyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFetchMajorIncidents>().To<FetchMajorIncidents>().InSingletonScope();
        }
    }
}