using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.GenericRepository;
namespace DataModel.UnitOfWork
{
    public interface IUnitOfWork
    {

        #region Properties
        GenericRepository<Product> ProductRepository { get; }
        GenericRepository<UserInformation> UserRepository { get; }
        GenericRepository<Token> TokenRepository { get; }
        GenericRepository<InventoryItemGroup> InventoryItemGroupRepository { get; }
        GenericRepository<InventoryItem> InventoryItemRepository { get; }
        GenericRepository<InventoryItemCategory> InventoryItemCategoryRepository { get; }
        GenericRepository<AccountsHeadAccount> AccountsHeadAccountRepository { get; }
        GenericRepository<AccountsGroupAccount> AccountsGroupAccountRepository { get; }
        GenericRepository<AccountsDetailAccount> AccountsDetailAccountRepository { get; }
        GenericRepository<AccountsBalanceSheetNote> AccountsBalanceSheetNoteRepository { get; }
        GenericRepository<AccountsProfitLoseNote> AccountsProfitLoseNoteRepository { get; }
        GenericRepository<AccountsVoucherType> AccountsVoucherTypeRepository { get; }
        GenericRepository<AccountsTransactionVoucherHead> AccountsTransactionVoucherHeadRepository { get; }
        GenericRepository<InventoryTransactionSaleDetail> InventoryTransactionSaleDetailRepository { get; }
        GenericRepository<InventoryTransactionPurchaseHead> InventoryTransactionPurchaseHeadRepository { get; } 
        GenericRepository<InventoryTransactionPurchaseDetail> InventoryTransactionPurchaseDetailRepository { get; }
        #endregion


        /// <summary>
        /// Save method.
        /// </summary>
        void Save();
    }
}
