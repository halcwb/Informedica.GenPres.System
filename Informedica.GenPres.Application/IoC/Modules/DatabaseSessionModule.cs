using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Informedica.GenPres.DataAcess;
using Raven.Client;

namespace Informedica.GenPres.Application.IoC.Modules
{
    public class DatabaseSessionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => x.Resolve<IDatabaseContext>().OpenSession())
           .As<IDocumentSession>()
           .InstancePerLifetimeScope()
           .OnRelease(x =>
           {
               // When the scope is released, save changes
               //  before disposing the session.
               x.SaveChanges();
               x.Dispose();
           });
        }
    }
}
