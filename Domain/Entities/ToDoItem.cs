using Domain.Identity;
using System;

namespace Domain.Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime DueIn { get; set; }
        public string Description { get; set; }


        public User User { get; set; }
        public ToDoItemStatus Status { get; set; }
    }
}
