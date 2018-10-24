using BusinessEntities;
using System.Collections.Generic;

namespace BusinessServices.Interface
{
    public interface IAccountsVoucherType
    {
        AccountsVoucherTypeEntity GetVoucherTypeById(int id);
        IEnumerable<AccountsVoucherTypeEntity> GetAllVoucherType();
        int CreateVoucherType(AccountsVoucherTypeEntity accountsVoucherTypeEntity);
        bool UpdateVoucherType(int id,AccountsVoucherTypeEntity accountsVoucherTypeEntity);
        bool DeleteVoucherType(int id);
    }
}
