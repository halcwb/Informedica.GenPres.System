using Autofac;
using Informedica.GenPres.Application.IoC.Modules;

namespace Informedica.GenPres.Application.IoC
{
    public static class MvcApplication
    {
        public static ContainerBuilder GetIoCBuilder()
       {
           var builder = new ContainerBuilder();
           //builder.RegisterControllers(Assembly.GetExecutingAssembly());           
           builder.RegisterModule(new DatabaseContextModule(true, ""));
           builder.RegisterModule(new DatabaseSessionModule());
           builder.RegisterModule(new RepositoriesModule());
           return builder;
       }
    }
}
