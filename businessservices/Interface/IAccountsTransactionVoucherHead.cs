using BusinessEntities;
using System.Collections.Generic;

namespace BusinessServices.Interface
{
    public interface IAccountsTransactionVoucherHead
    {
        AccountsTransactionVoucherHeadEntity GetAccountsVoucherHeadById(int id);
        IEnumerable<AccountsTransactionVoucherHeadEntity> GetAllAccountsVoucherHeads();
        int CreateTransactionVoucherHead(AccountsTransactionVoucherHeadEntity accountsTransactionVoucherHeadEntity);
        bool UpdateTransactionVoucherHead(AccountsTransactionVoucherHeadEntity accountsTransactionVoucherHeadEntity);
        bool DeleteTransactionVoucherHead(int id);
    }
}
