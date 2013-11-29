using Nancy;
using Nancy.Bootstrappers.Ninject;
using Ninject;
using RfsForChrome.Service.Infrastructure;

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
            container.Load<FireSearchModule>();

            
        }
         
    }
}