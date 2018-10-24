using BusinessEntities;
using System.Collections.Generic;

namespace BusinessServices.Interface
{
    public interface IInventoryTransactionPurchaseHead
    {
        InventoryTransactionPurchaseHeadEntity GetInventoryTransactionPurchaseHeadById(int id);
        IEnumerable<InventoryTransactionPurchaseHeadEntity> GetAllInventoryTransactionPurchaseHeads();
        int CreateInventoryTransactionPurchaseHead(InventoryTransactionPurchaseHeadEntity inventoryTransactionPurchaseHeadEntity);
        bool UpdateInventoryTransactionPurchaseHead(int id, InventoryTransactionPurchaseHeadEntity inventoryTransactionPurchaseHeadEntity);
        bool DeleteInventoryTransactionPurchaseHead(int id); 
    }
}
