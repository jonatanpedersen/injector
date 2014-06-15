using System.Data.Entity;

namespace Injector.UI.Models
{
    public class InjectionContext : DbContext
    {
        public DbSet<Injection> Injections { get; set; }
    }
}