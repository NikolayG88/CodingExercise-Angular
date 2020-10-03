using Application.Interfaces;
using System;

namespace CodingExercise.API.Models
{
    public class AddToDoItemModel : IToDoItem
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime DueIn { get; set; }
        public string Description { get; set; }
        public IToDoItemStatus Status { get; set; }
    }
}