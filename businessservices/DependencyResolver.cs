using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices.Interface;
using Resolver;
using BusinessServices.Services;

namespace BusinessServices
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IProductServices, ProductServices>();
            //dependency type so that we get UserServices dependency resolved at run time
            registerComponent.RegisterType<IUserService,UserServices>();
            // dependency resolver for token
            registerComponent.RegisterType<ITokenServices,TokenServices>();
            //resolver for balance sheet note
            registerComponent.RegisterType<IAccountsBalanceSheetNote, AccountsBalanceSheetNoteServices>();
            //resolver detail account
            registerComponent.RegisterType<IAccountsDetailAccount, AccountsDetailAccountServices>();
            //resolver group account
            registerComponent.RegisterType<IAccountsGroupAccount, AccountsGroupAccountServices>();
            //resolver head account
            registerComponent.RegisterType<IAccountsHeadAccount, AccountsHeadAccountServices>();
            //resolver profit lose 
            registerComponent.RegisterType<IAccountsProfitLoseNote, AccountsProfitLoseNoteServices>();
            //resolver trans voucher head
            registerComponent.RegisterType<IAccountsTransactionVoucherHead, AccountsTransactionVoucherHeadServices>();
            //resolver voucher type
            registerComponent.RegisterType<IAccountsVoucherType, AccountsVoucherTypeServices>();
            //Inventory Item services
            registerComponent.RegisterType<IInventoryItem, InventoryItemServices>();
            // inventory Item category
            registerComponent.RegisterType<IInventoryItemCategory, InventoryItemCategoryServices>();
            // inventory group
            registerComponent.RegisterType<IInventoryItemGroupServices, InventoryItemGroupServices>();
            //inventory transaction purachse detail
            registerComponent.RegisterType<IInventoryTransactionPurchaseDetail, InventoryTransactionPurchaseDetailServices>();
            //inventory trans purachse head
            registerComponent.RegisterType<IInventoryTransactionPurchaseHead, InventoryTransactionPurchaseHeadServices>();
            //inventory sale details
            registerComponent.RegisterType<IInventoryTransactionSaleDetail, InventoryTransactionSaleDetailServices>();




        }
    }
}
