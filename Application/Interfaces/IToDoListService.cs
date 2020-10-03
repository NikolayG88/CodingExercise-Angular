using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IToDoListService
    {
        IList<IToDoItem> GetToDoItems(string userId);
        void AddToDoItem(IToDoItem item, string userId);
        void SetItemStatus(int itemId, int itemStatusId);

    }
}
