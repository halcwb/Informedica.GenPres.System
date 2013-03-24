using Autofac;
using Autofac.Integration.Mvc;
using Informedica.Service.Presentation;

namespace Informedica.GenPres.Application.IoC.Modules
{
    public class ServicesModule : Module
    {
        //override Load method
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginService>().As<ILoginService>().InstancePerHttpRequest();
            builder.RegisterType<PatientService>().As<IPatientService>().InstancePerHttpRequest();
        }
    }
}
