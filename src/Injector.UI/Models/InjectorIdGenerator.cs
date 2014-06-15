using System;

namespace Injector.UI.Models
{
    public class InjectorIdGenerator : IInjectorIdGenerator
    {
        public string Generate()
        {
            return Guid.NewGuid().GetHashCode().ToString().Replace("-", "");
        }
    }
}