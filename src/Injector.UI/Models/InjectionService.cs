using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Injector.UI.Models
{
    public class InjectionService : IInjectionService
    {
        public InjectionDto[] FindInjections(string injectorId)
        {
            using (var context = new InjectorContext())
            {
                return context.Injections
                    .Where(o => o.InjectorId == injectorId)
                    .Select(o => new InjectionDto
                    {
                        Url = o.Url,
                        QuerySelector = o.QuerySelector,
                        Html = o.Html,
                        Id = o.Id,
                        InjectorId = o.InjectorId,
                        Name = o.Name,
                    })
                    .ToArray();
            }
        }

        public InjectionForUrlDto[] FindInjectionsForUrl(string injectorId, string url)
        {
            using (var context = new InjectorContext())
            {
                return context.Injections
                    .Where(o => o.InjectorId == injectorId)
                    .ToArray()
                    .Where(o => Regex.IsMatch(url, o.Url))
                    .Select(o => new InjectionForUrlDto
                    {
                        QuerySelector = o.QuerySelector,
                        Html = o.Html,
                    })
                    .ToArray();
            }
        }
        public void DeleteInjection(Guid id)
        {
            using (var context = new InjectorContext())
            {
                var injection = context.Injections.FirstOrDefault(o => o.Id == id);

                context.Injections.Remove(injection);

                context.SaveChanges();
            }
        }

        public void CreateInjection(InjectionDto injectionDto)
        {
            using (var context = new InjectorContext())
            {
                var injection = new Injection()
                {
                    Id = Guid.NewGuid(),
                    InjectorId = injectionDto.InjectorId,
                    Url = injectionDto.Url,
                    Html = injectionDto.Html,
                    Name = injectionDto.Name,
                    QuerySelector = injectionDto.QuerySelector,
                };

                context.Injections.Add(injection);

                context.SaveChanges();
            }
        }

        public void UpdateInjection(InjectionDto injectionDto)
        {
            using (var context = new InjectorContext())
            {
                var injection = context.Injections.FirstOrDefault(o => o.Id == injectionDto.Id);

                injection.Url = injectionDto.Url;
                injection.Html = injectionDto.Html;
                injection.Name = injectionDto.Name;
                injection.QuerySelector = injectionDto.QuerySelector;

                context.SaveChanges();
            }
        }
    }
}