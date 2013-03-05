using Autofac;
using Autofac.Integration.Mvc;
using Informedica.Data.Repositories;

namespace Informedica.GenPres.Application.IoC.Modules
{
    public class RepositoriesModule : Module
    {
        //override Load method
        protected override void Load(ContainerBuilder builder)
        {
          //say that for any IUsersRepository we need UsersRepository class to be invoked
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerHttpRequest();
        }
    }
}
