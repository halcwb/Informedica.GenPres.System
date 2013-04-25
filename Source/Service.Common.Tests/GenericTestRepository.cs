using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informedica.Data.Repositories;

namespace Service.Common.Tests
{
    public class GenericTestRepository : EntityRepository
    {
        public GenericTestRepository(IDocumentSession session) : base(session)
        {
        }
    }
}
