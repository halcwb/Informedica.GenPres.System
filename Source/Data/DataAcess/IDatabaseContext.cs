using System;
using Raven.Client;

namespace Informedica.GenPres.DataAcess
{
    public interface IDatabaseContext : IDisposable
    {
        IDocumentSession OpenSession();
        void Initialize();
    }
}