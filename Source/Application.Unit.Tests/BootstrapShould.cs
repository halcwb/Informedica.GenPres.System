using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Informedica.GenPres.Application;
using Informedica.GenPres.Application.IoC;
using NUnit.Framework;
using Informedica.Data.Repositories;

namespace Application.Unit.Tests
{
    public class BootstrapShould
    {
        [SetUp]
        public void SetUp()
        {
            var builder = MvcApplication.BuildTestIoC();
            var container = builder.Build();
            var lifetimeScopeProvider = new StubLifetimeScopeProvider(container);
            var resolver = new AutofacDependencyResolver(container, lifetimeScopeProvider);
            DependencyResolver.SetResolver(resolver);
        }
        
        [Test]
        public void CreatARepositoryWithASession()
        {
            var repos = DependencyResolver.Current.GetService<IUserRepository>();
            Assert.IsNotNull(repos);
        }

        [Test]
        public void ThrowAnExceptionWhenGetSessionIsCalledWithoutInitialize()
        {
            
        }
    }
}
