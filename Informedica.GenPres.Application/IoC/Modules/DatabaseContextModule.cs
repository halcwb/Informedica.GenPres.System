using System;
using Autofac;
using Informedica.GenPres.DataAcess;
using Informedica.GenPres.DataAcess.RavenDb;
using Raven.Client;
using Raven.Client.Document;

namespace Informedica.GenPres.Application.IoC.Modules
{
    public class DatabaseContextModule : Module
    {
        private readonly bool _inMemory = false;
        private readonly string _connectionString;

        public DatabaseContextModule(bool inMemory, string connectionString = "")
        {
            this._inMemory = inMemory;
            this._connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                IDatabaseContext store = null;

                if (this._inMemory == true)
                {
                    store = new RavenDbTestContext();
                }
                else if (!string.IsNullOrEmpty(this._connectionString))
                {
                    store = new RavenDbContext(_connectionString);
                }
                else
                {
                    throw new InvalidDatabaseContextConfiguration();
                }

                store.Initialize();
                return store;
            })
           .As<IDatabaseContext>()
           .SingleInstance();
        }
    }

    public class InvalidDatabaseContextConfiguration : Exception
    {
        public override string Message
        {
            get
            {
                return "Neither a connectionstring nor a inMemory sepecication is provided.";
            }
        }
    }
}
