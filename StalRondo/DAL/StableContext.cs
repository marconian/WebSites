using StalRondo.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace StalRondo.DAL
{
    public class StableContext : DbContext
    {
        public StableContext() : base("StableContext")
        {
        }

        public DbSet<Horse> Herd { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Genealogy> GenealogyTree { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}