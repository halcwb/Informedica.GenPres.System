using System.Web.Mvc;
using Informedica.GenPres.Application.IoC;

namespace Informedica.GenPres.Application
{
    public class TestSetup
    {
        public TestSetup()
        {
            var builder = MvcApplication.BuildIoC();
        }
    }
}
