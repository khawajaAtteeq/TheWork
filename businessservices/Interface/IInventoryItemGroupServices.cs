using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices
{
    public interface IInventoryItemGroupServices
    {
        InventoryItemGroupEntity GetItemGroupById(int id);
        IEnumerable<InventoryItemGroupEntity> GetAllItemGroups();
        int CreateItemGroup(InventoryItemGroupEntity inventoryDefineItemGroupEntity);
        bool UpdateItemGroup(int id, InventoryItemGroupEntity inventoryDefineItemGroupEntity);
        bool DeleteItemGroup(int id);
    }
}
