using System.Data.Entity;

namespace AngularDemo.Models
{
    public class Context : DbContext
    {
        public Context():base("StringDBContext") {}
        public DbSet<Angular> Angulars { get; set; }
    }
}