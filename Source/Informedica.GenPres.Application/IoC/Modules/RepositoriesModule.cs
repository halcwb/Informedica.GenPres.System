using Autofac;
using Autofac.Integration.Mvc;
using Informedica.Data.Repositories;

namespace Informedica.GenPres.Application.IoC.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EntityRepository>().As<IEntityRepository>().InstancePerHttpRequest();
            builder.RegisterType<PatientRepository>().As<IPatientRepository>().InstancePerHttpRequest();
        }
    }
}
