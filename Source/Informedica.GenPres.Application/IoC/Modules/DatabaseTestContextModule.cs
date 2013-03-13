using System;
using Autofac;
using Informedica.GenPres.DataAcess;
using Informedica.GenPres.DataAcess.RavenDb;
using Raven.Client;
using Raven.Client.Document;

namespace Informedica.GenPres.Application.IoC.Modules
{
    public class DatabaseTestContextModule : Module
    {
     
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                IDatabaseContext store = null;
                store = new RavenDbTestContext();
                store.Initialize();
                return store;
            })
           .As<IDatabaseContext>()
           .SingleInstance();
        }
    }
}
