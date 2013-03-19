using System.Linq;
using FluentAssertions;
using Informedica.GenPres.Business.Entities;
using NUnit.Framework;
using Raven.Client;
using Raven.Client.Embedded;
using Shared.Test;

namespace Informedica.Data.Repositories.Integration.Tests
{
    [TestFixture]
    public class ThatEntityRepository
    {
        private const string Entityname = "test";
        
        private IDocumentSession _session;
        private EmbeddableDocumentStore _documentStore;

        [SetUp]
        public void SetUp()
        {
            _documentStore = new EmbeddableDocumentStore
            {
                RunInMemory = true
            };

            _documentStore.Initialize();
            _session = _documentStore.OpenSession();
        }

        [TearDown]
        public void TearDown()
        {
            _session.Dispose();
            _documentStore.Dispose();
        }

        [Test]
        public void ShouldBeAbleToSaveAEntity()
        {
            var entityRepository = new EntityRepository(_session);
            var entity = new BusinessEntity { Name = "test" };
            entityRepository.Save(entity);
            entity.Id.Should().NotBeEmpty();
        }

        [Test]
        public void ShouldBeAbleToRetrieveAEntity()
        {
            var entity = new BusinessEntity { Name = "test" };
            _session.Store(entity);
            _session.SaveChanges();

            var entityRepository = new EntityRepository(_session);
            var getEntity = entityRepository.GetSingle<BusinessEntity>(x => x.Name == Entityname);
            
            AssertAll.Succeed(
                () => Assert.IsNotNullOrEmpty(getEntity.Id, "Id should be retrieved"),
                () => Assert.IsNotNullOrEmpty(getEntity.Name, "Password should be retrieved")
            );
        }

        [Test]
        public void ShouldBeAbleToGetAllEntitys()
        {
            var entity1 = new BusinessEntity { Name = "test" };
            var entity2 = new BusinessEntity { Name = "test" };
            _session.Store(entity1);
            _session.Store(entity2);
            _session.SaveChanges();

            var entityRepository = new EntityRepository(_session);
            var entitys = entityRepository.GetAll<BusinessEntity>();
            entitys.Count.Should().Be(2);
        }

        [Test]
        public void SavingAnExistingEntityShouldNotChangeId()
        {
            var entity = new BusinessEntity { Name = "test" };
            _session.Store(entity);
            _session.SaveChanges();

            var entityRepository = new EntityRepository(_session);
            var entityGet = entityRepository.GetSingle<BusinessEntity>(x => x.Name == Entityname);
            entityRepository.Save(entityGet);
            entityGet.Id.Should().Be(entity.Id);
        }
    }


    public class BusinessEntity: Entity
    {
        public string Name { get; set; }
    }
}
