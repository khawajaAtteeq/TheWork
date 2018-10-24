using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices
{
    public interface IInventoryItemCategory
    {
        InventoryItemCategoryEntity GetItemCategoryById(int id);
        IEnumerable<InventoryItemCategoryEntity> GetAllItemCategory();
        int CreateItemCategory(InventoryItemCategoryEntity inventoryItemCategory);
        bool UpdateItemCategory(int id, InventoryItemCategoryEntity inventoryItemCategory);
        bool DeleteItemCatygory(int id);
    }
}
