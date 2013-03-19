using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using Informedica.Service.Presentation;
using Informedica.Data.Repositories;

namespace Informedica.GenPres.Application.IoC.Modules
{
    public class ServicesModule : Module
    {
        //override Load method
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginService>().As<ILoginService>().InstancePerHttpRequest();
        }
    }
}
