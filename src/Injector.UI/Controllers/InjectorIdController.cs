using Injector.UI.Models;
using System.Web.Http;

namespace Injector.UI.Controllers
{
    public class InjectorIdController : ApiController
    {
        private readonly IInjectorIdGenerator injectorIdGenerator;

        public InjectorIdController()
        {
            this.injectorIdGenerator = new InjectorIdGenerator();
        }

        public string Get()
        {
            return injectorIdGenerator.Generate();
        }
    }
}