using System.Data.Entity;

namespace Injector.UI.Models
{
    public class InjectorContext : DbContext
    {
        public DbSet<Injection> Injections { get; set; }
    }
}