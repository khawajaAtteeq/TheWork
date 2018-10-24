using BusinessEntities;
using System.Collections.Generic;

namespace BusinessServices.Interface
{
    public interface IAccountsGroupAccount
    {
        AccountsGroupAccountEntity GetAccountsGroupById(int id);
        IEnumerable<AccountsGroupAccountEntity> GetAllAccountsGroups();
        int CreateGroupAccount(AccountsGroupAccountEntity accountsGroupAccountEntity);
        bool UpdateGroupAccount(int id, AccountsGroupAccountEntity accountsGroupAccountEntity);
        bool DeleteGroupAccount(int id);
    }
}
