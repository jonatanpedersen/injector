using System;

namespace Injector.UI.Models
{
    public class Injection
    {
        public Guid Id { get; set; }
        public string InjectorId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string QuerySelector { get; set; }
        public string Html { get; set; }
    }
}