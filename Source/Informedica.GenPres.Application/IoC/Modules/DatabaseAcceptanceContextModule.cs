using System;
using Autofac;
using Informedica.GenPres.DataAcess;
using Informedica.GenPres.DataAcess.RavenDb;
using Raven.Client;
using Raven.Client.Document;

namespace Informedica.GenPres.Application.IoC.Modules
{
    public class DatabaseAcceptanceContextModule : Module
    {
        private readonly string _url;
        private readonly string _databaseName;

        public DatabaseAcceptanceContextModule(string url, string databaseName)
        {
            _url = url;
            _databaseName = databaseName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                IDatabaseContext store = null;
                store = new RavenDbContext(_url, _databaseName);
                store.Initialize();
                return store;
            })
           .As<IDatabaseContext>()
           .SingleInstance();
        }
    }
}
