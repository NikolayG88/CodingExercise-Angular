using System.Collections.Generic;
using Application.Interfaces;
using Domain.Entities;
using AutoMapper;
using System.Linq;
using Domain.Enums;

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

        public int AddToDoItem(IToDoItem item, string userId)
        {
            var newItem = _mapper.Map<ToDoItem>(item);

            newItem.UserId = userId;

            _context.ToDoItems.Add(newItem);

            _context.SaveChanges();

            return newItem.Id;
        }

        public IList<IToDoItem> GetToDoItems(string userId)
        {
            return _mapper.Map<IList<IToDoItem>>( _context.ToDoItems.Where(i => i.UserId == userId));
        }

        public void SetItemStatusDone(int itemId)
        {
            _context.ToDoItems.FirstOrDefault(t => t.Id == itemId).StatusId = (int)ToDoItemStatusEnum.Done;

            _context.SaveChanges();
        }

        public void DeleteToDoItem(int itemId)
        {
            var item = _context.ToDoItems.FirstOrDefault(itm => itm.Id == itemId);
            _context.ToDoItems.Remove(item);
            _context.SaveChanges();
        }
    }
}
