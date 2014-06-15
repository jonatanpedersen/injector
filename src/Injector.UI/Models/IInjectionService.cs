using System;

namespace Injector.UI.Models
{
    public interface IInjectionService
    {
        InjectionDto[] FindInjections(string injectorId);
        InjectionForUrlDto[] FindInjectionsForUrl(string injectorId, string url);
        void DeleteInjection(Guid id);
        void CreateInjection(InjectionDto injectionDto);
        void UpdateInjection(InjectionDto injectionDto);
    }
}
