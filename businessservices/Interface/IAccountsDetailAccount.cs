using BusinessEntities;
using System.Collections.Generic;

namespace BusinessServices.Interface
{
    public interface IAccountsDetailAccount
    {
        AccountsDetailAccountEntity GetDetailAccountById(int id);
        IEnumerable<AccountsDetailAccountEntity> GetAllDetailAccount();
        int CreateDetailAccount(AccountsDetailAccountEntity accountsDetailAccountEntity);
        bool UpdateDetailAccount(int id, AccountsDetailAccountEntity accountsDetailAccountEntity);
        bool DeleteDetailAccount(int id);
    }
}
