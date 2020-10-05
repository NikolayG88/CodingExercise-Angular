namespace Persistance.Migrations
{
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity;
    using Domain.Identity;
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using Domain.Entities;
    using System.Net.Configuration;
    using Application.Services;
    using Domain.Enums;
    using System.Security.Cryptography.X509Certificates;

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
            SeedStubData(context);
#if (DEBUG)
            SeedTestUsers(context);
            SeedSampleData(context);
#endif
         
        }

        private void SeedSampleData(AppDbContext context)
        {
            if (context.ToDoItems.Any()) return;

            var userId = context.Users.First().Id;
            var items = new List<ToDoItem> {
            new ToDoItem
                {
                    Name = "Buy groceries",
                    Description = "Milk, Cheese, Potates, Onions, Rice, Yoghurt, Sausage",
                    DueIn = DateTime.Now.AddHours(5),
                    UserId = userId,
                    StatusId = (int)ToDoItemStatusEnum.DueSoon
                }

            };

            context.ToDoItems.AddRange(items);

            context.SaveChanges();
        }

        private void SeedTestUsers(AppDbContext context)
        {
            if (context.Users.Any()) return;
            
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

        private void SeedStubData(AppDbContext context)
        {
            if (context.ToDoItemStatuses.Any()) return;

            var statuses = new List<ToDoItemStatus> {
                new ToDoItemStatus
                {
                    Id = (int)ToDoItemStatusEnum.ToDo,
                    Status = "ToDo",
                    Description = "Item that shold be done."
                },
                new ToDoItemStatus
                {
                    Id = (int)ToDoItemStatusEnum.DueSoon,
                    Status = "DueSoon",
                    Description = "Item that has less than 12 hours to complete"
                },
                new ToDoItemStatus
                {
                    Id = (int)ToDoItemStatusEnum.DuePast,
                    Status = "DuePast",
                    Description = "Item that shold have been done."
                },
                new ToDoItemStatus
                {
                    Id = (int)ToDoItemStatusEnum.Done,
                    Status = "Done",
                    Description = "Item that have been done."
                }
            };


            context.ToDoItemStatuses.AddRange(statuses);

            context.SaveChanges();
        }
    }
}
