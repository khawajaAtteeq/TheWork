using BusinessEntities;
using System.Collections.Generic;

namespace BusinessServices.Interface
{
    public interface IInventoryTransactionPurchaseDetail
    {
        InventoryTransactionPurchaseDetailEntity GetInventoryTransactionPurchaseDetailById(int id);
        IEnumerable<InventoryTransactionPurchaseDetailEntity> GetAllInventoryTransactionPurchaseDetails();
        int CreateInventoryTransactionPurchaseDetail(InventoryTransactionPurchaseDetailEntity inventoryTransactionPurchaseDetailEntity);
        bool UpdateInventoryTransactionPurchaseDetail(int id, InventoryTransactionPurchaseDetailEntity inventoryTransactionPurchaseDetailEntity);
        bool DeleteInventoryTransactionPurchaseDetail(int id); 
    }
}
