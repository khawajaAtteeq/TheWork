using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices.Interface
{
    public interface IAccountsHeadAccount
    {
        AccountsHeadAccountEntity GetAccountsHeadById(int id);
        IEnumerable<AccountsHeadAccountEntity> GetAllAccountsHeads();
        int CreateHeadAccount(AccountsHeadAccountEntity accountsHeadAccountEntity);
        bool UpdateHeadAccount(int id, AccountsHeadAccountEntity accountsHeadAccountEntity);
        bool DeleteHeadAccount(int id);
    }
}
