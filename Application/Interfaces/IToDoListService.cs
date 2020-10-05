using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IToDoListService
    {
        IList<IToDoItem> GetToDoItems(string userId);
        int AddToDoItem(IToDoItem item, string userId);
        void SetItemStatusDone(int itemId);

        void DeleteToDoItem(int itemId);

    }
}
