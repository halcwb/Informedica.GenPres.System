using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Informedica.GenPres.Application;

namespace Application.Unit.Tests.IoC
{
    public abstract class IoCTestBase
    {
        protected void BuildAndCreateTestDependencyResolver(ContainerBuilder builder)
        {
            var container = builder.Build();
            var lifetimeScopeProvider = new StubLifetimeScopeProvider(container);
            var resolver = new AutofacDependencyResolver(container, lifetimeScopeProvider);
            DependencyResolver.SetResolver(resolver);
        }
    }
}
