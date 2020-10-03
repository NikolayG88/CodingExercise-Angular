using System.Data.Entity;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<ToDoItem> ToDoItems { get; set; }
        DbSet<ToDoItemStatus> ToDoItemStatuses { get; set; }

        int SaveChanges();
    }
}
