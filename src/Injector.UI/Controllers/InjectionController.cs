using System;
using System.Web.Http;
using Injector.UI.Models;

namespace Injector.UI.Controllers
{
    public class InjectionController : ApiController
    {
        private readonly IInjectionService injectionService;

        public InjectionController()
        {
            this.injectionService = new InjectionService();
        }

        public InjectionDto[] Get(string injectorId)
        {
            return injectionService.FindInjections(injectorId);
        }

        public void Post(InjectionDto injectionDto)
        {
            injectionService.CreateInjection(injectionDto);
        }

        public void Put(InjectionDto injectionDto)
        {
            injectionService.UpdateInjection(injectionDto);
        }

        public void Delete(Guid id)
        {
            injectionService.DeleteInjection(id);
        }
    }
}