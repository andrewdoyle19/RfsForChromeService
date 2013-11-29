using System;
using System.Configuration;
using Ninject.Modules;

namespace RfsForChrome.Service.Infrastructure
{
    public class FireSearchModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFetchMajorIncidents>().To<FetchMajorIncidents>()
                .InSingletonScope()
                .WithConstructorArgument("majorIncidentsUrl", c =>
                    {
                        string url = ConfigurationManager.AppSettings["MajorIncidentsUrl"];
                        return new Uri(url);
                    });

            Bind<IOrderAndModelIncidents>().To<OrderAndModelIncidents>();
        }
    }
}