﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using Presentation;
using Repositories;

namespace Informedica.GenPres.Application.IoC.Modules
{
    public class ServicesModule : Module
    {
        //override Load method
        protected override void Load(ContainerBuilder builder)
        {
            //say that for any IUsersRepository we need UsersRepository class to be invoked
            builder.RegisterType<LoginService>().As<ILoginService>().InstancePerHttpRequest();
        }
    }
}