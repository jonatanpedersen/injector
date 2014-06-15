using System;
using System.Web.Http;
using Injector.UI.Models;

namespace Injector.UI.Controllers
{
    public class InjectionForUrlController : ApiController
    {
        private readonly IInjectionService injectionService;

        public InjectionForUrlController()
        {
            this.injectionService = new InjectionService();
        }

        public InjectionForUrlDto[] Get(string injectorId, string url)
        {
            return injectionService.FindInjectionsForUrl(injectorId, url);
        }
    }
}