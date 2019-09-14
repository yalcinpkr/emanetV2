using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emanetV2.Data
{
    class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalSize> AnimalSizes { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }

    }
}
