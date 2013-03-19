using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Informedica.GenPres.Business.Entities
{
    public class Patient : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LogicalUnitId { get; set; }
        
        public Patient()
        {
            FirstName = "";
            LastName = "";
        }
    }
}
