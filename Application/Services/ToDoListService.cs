using System.Collections.Generic;
using Application.Interfaces;
using Domain.Entities;
using AutoMapper;

namespace Application.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IMapper _mapper;
        private readonly IAppDbContext _context;
        public ToDoListService(IAppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddToDoItem(IToDoItem item, string userId)
        {
            var newItem = _mapper.Map<ToDoItem>(item);

            _context.ToDoItems.Add(newItem);
            _context.SaveChanges();
        }

        public IList<IToDoItem> GetToDoItems(string userId)
        {
            throw new System.NotImplementedException();
        }

        public void SetItemStatus(int itemId, int itemStatusId)
        {
            throw new System.NotImplementedException();
        }
    }
}
