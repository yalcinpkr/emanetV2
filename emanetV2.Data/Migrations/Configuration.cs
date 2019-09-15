namespace emanetV2.Data.Migrations
{
    using emanetV2.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<emanetV2.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(emanetV2.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Statuses.AddOrUpdate(x => x.Id,
            new Status() { Id = 1, Name = "Yayýnda" },
  new Status() { Id = 2, Name = "Taslak" },
  new Status() { Id = 3, Name = "Silindi" }
                         );

        }
    }
}
