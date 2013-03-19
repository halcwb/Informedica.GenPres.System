using Autofac;
using Informedica.GenPres.Application.IoC.Modules;

namespace Informedica.GenPres.Application.IoC
{
    public static class MvcApplication
    {
       public static ContainerBuilder BuildIoC()
       {
           var builder = new ContainerBuilder();
           builder.RegisterModule(new DatabaseTestContextModule());
           builder.RegisterModule(new DatabaseSessionModule());
           builder.RegisterModule(new RepositoriesModule());
           builder.RegisterModule(new ServicesModule());
           return builder;
       }
    }
}
