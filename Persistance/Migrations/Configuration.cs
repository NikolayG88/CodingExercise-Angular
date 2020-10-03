namespace Persistance.Migrations
{
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity;
    using Domain.Identity;
    using System.Linq;
    using System;

    internal sealed class Configuration : DbMigrationsConfiguration<Persistance.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
#if (DEBUG)
            SeedSampleData(context);
            SeedTestUsers(context);
#endif
        }

        private void SeedSampleData(AppDbContext context)
        {


        }

        private void SeedTestUsers(AppDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var hasher = new PasswordHasher();

            context.Users.AddOrUpdate(new User
            {
                UserName = "Test",
                Email = "Test@mail.com",
                PasswordHash = hasher.HashPassword("Test1!"),
                SecurityStamp = Guid.NewGuid().ToString()
            });


            context.SaveChanges();
        }
    }
}
