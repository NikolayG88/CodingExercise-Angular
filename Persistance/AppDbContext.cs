using Microsoft.AspNet.Identity.EntityFramework;
using Application.Interfaces;
using System.Data.Entity;
using Domain.Entities;
using Domain.Identity;

namespace Persistance
{
    public class AppDbContext : IdentityDbContext<User>, IAppDbContext
    {
        public AppDbContext() : base("DefaultConnectionString")
        {

        }

        public virtual DbSet<ToDoItem> ToDoItems { get; set; }

        public virtual DbSet<ToDoItemStatus> ToDoItemStatuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<ToDoItem>().HasKey(t => t.Id);

            builder.Entity<ToDoItem>().Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Entity<ToDoItem>()
                .HasRequired(t => t.User).WithMany()
                .HasForeignKey(t => t.UserId);

            builder.Entity<ToDoItem>().HasRequired(t => t.Status).WithMany().HasForeignKey(t => t.StatusId);

            builder.Entity<ToDoItem>().Property(t => t.Description)
                .HasMaxLength(500)
                .IsRequired();


            builder.Entity<ToDoItemStatus>().HasKey(s => s.Id);
            builder.Entity<ToDoItemStatus>().Property(s => s.Status)
                .HasMaxLength(50)
                .IsRequired();
            builder.Entity<ToDoItemStatus>().Property(s => s.Description)
                .HasMaxLength(200)
                .IsRequired();
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        //public override int SaveChanges()
        //{
        //    return base.SaveChanges();
        //}
    }
}
