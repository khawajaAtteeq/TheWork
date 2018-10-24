using BusinessEntities;
using DataModel;
using System.Collections.Generic;

namespace BusinessServices
{
    public interface IInventoryItem
    {
        InventoryItemEntity GetItemById(int id);
        IEnumerable<InventoryItemEntity> GetAllItems();
        int CreateInventoryItem(InventoryItemEntity inventoryItem);
        bool UpdateInventoryItem(int id, InventoryItemEntity  inventoryItem);
        bool DeleteInventoryItem(int id);
    }
}
