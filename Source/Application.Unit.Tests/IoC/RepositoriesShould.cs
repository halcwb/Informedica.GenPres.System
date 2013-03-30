using System.Web.Mvc;
using Autofac;
using FluentAssertions;
using Informedica.GenPres.Application.IoC.Modules;
using Informedica.GenPres.DataAcess;
using NUnit.Framework;
using Raven.Client;
using Informedica.Data.Repositories;
using Rhino.Mocks;

namespace Application.Unit.Tests.IoC
{
    public class RepositoriesShould : IoCTestBase
    {
        [SetUp]
        public void SetUp()
        {
            var builder = new ContainerBuilder();

            var stubDocumentSession = MockRepository.GenerateStub<IDocumentSession>();

            builder.RegisterInstance(stubDocumentSession).As<IDocumentSession>();

            builder.RegisterModule<RepositoriesModule>();

            base.BuildAndCreateTestDependencyResolver(builder);
        }

        [Test]
        public void EntityRepositoryToBeResolvable()
        {
            var entityRepos = DependencyResolver.Current.GetService<IEntityRepository>();
            entityRepos.Should().NotBeNull();
        }

        [Test]
        public void PatientRepositoryToBeResolvable()
        {
            var patientRepos = DependencyResolver.Current.GetService<IPatientRepository>();
            patientRepos.Should().NotBeNull();
        }

        [Test]
        public void EntityRepositoryToBeSameInCurrentScope()
        {
            var userRep1 = DependencyResolver.Current.GetService<IEntityRepository>();
            var userRep2 = DependencyResolver.Current.GetService<IEntityRepository>();
            userRep1.Should().BeSameAs(userRep2);
        }

        [Test]
        public void PatientRepositoryToBeSameInCurrentScope()
        {
            var patientRepos1 = DependencyResolver.Current.GetService<IPatientRepository>();
            var patientRepos2 = DependencyResolver.Current.GetService<IPatientRepository>();
            patientRepos1.Should().BeSameAs(patientRepos2);
        }
    }
}
