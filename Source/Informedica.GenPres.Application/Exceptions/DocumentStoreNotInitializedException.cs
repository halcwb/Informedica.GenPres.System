using System;

namespace Informedica.GenPres.Application.Exceptions
{
    public class DocumentStoreNotInitializedException : Exception
    {
        public DocumentStoreNotInitializedException(string message) :base(message)
        {
            
        }
    }
}
