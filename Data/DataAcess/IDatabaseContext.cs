using Raven.Client;

namespace Informedica.GenPres.DataAcess
{
    public interface IDatabaseContext
    {
        IDocumentSession OpenSession();
        void Initialize();
    }
}