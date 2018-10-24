using BusinessEntities;
using System.Collections.Generic;

namespace BusinessServices.Interface
{
    public interface IInventoryTransactionSaleDetail
    {
        InventoryTransactionSaleDetailEntity GetInventoryTransactionSaleDetailById(int id);
        IEnumerable<InventoryTransactionSaleDetailEntity> GetAllInventoryTransactionSaleDetails();
        int CreateInventoryTransactionSaleDetail(InventoryTransactionSaleDetailEntity inventoryTransactionSaleDetailEntity);
        bool UpdateInventoryTransactionSaleDetail(int id, InventoryTransactionSaleDetailEntity inventoryTransactionSaleDetailEntity);
        bool DeleteInventoryTransactionSaleDetail(int id); 
    }
}
