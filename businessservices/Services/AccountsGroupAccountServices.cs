using DataModel;
using AutoMapper;
using System.Linq;
using BusinessEntities;
using System.Transactions;
using DataModel.UnitOfWork;
using System.Collections.Generic;
using BusinessServices.Interface;

namespace BusinessServices.Services
{
    public class AccountsGroupAccountServices: IAccountsGroupAccount
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountsGroupAccountServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AccountsGroupAccountServices()
        {

        }

        public AccountsGroupAccountEntity GetAccountsGroupById(int id)
        {
            var group = _unitOfWork.AccountsGroupAccountRepository.GetById(id);
            if (group != null)
            {
                Mapper.CreateMap<AccountsGroupAccount, AccountsGroupAccountEntity>();
                var groupModel = Mapper.Map<AccountsGroupAccount, AccountsGroupAccountEntity>(group);
                return groupModel;
            }
            return null;
        }

        public IEnumerable<AccountsGroupAccountEntity> GetAllAccountsGroups()
        {
            var group = _unitOfWork.AccountsGroupAccountRepository.GetAll().ToList();
            if (group != null)
            {
                Mapper.CreateMap<AccountsGroupAccount, AccountsGroupAccountEntity>();
                var groupModel = Mapper.Map<List<AccountsGroupAccount>, List<AccountsGroupAccountEntity>>(group);
                return groupModel;
            }
            return null;
        }

        public int CreateGroupAccount(AccountsGroupAccountEntity accountsGroupAccountEntity)
        {
            using(var scope=new TransactionScope())
            {
                var group = new AccountsGroupAccount
                {
                    GroupAccountCode=accountsGroupAccountEntity.GroupAccountCode,
                    GroupAccountName=accountsGroupAccountEntity.GroupAccountName,
                    MainAccountId=accountsGroupAccountEntity.MainAccountId,
                    SortOrder=accountsGroupAccountEntity.SortOrder,
                    IsActive=accountsGroupAccountEntity.IsActive
                };
                _unitOfWork.AccountsGroupAccountRepository.Insert(group);
                _unitOfWork.Save();
                scope.Complete();
                return group.Id;
            }
        }

        public bool UpdateGroupAccount(int id, AccountsGroupAccountEntity accountsGroupAccountEntity)
        {
            var success = false;
            if (accountsGroupAccountEntity != null)
            {
                var group = _unitOfWork.AccountsGroupAccountRepository.GetById(id);
                if (group != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        group.GroupAccountCode = accountsGroupAccountEntity.GroupAccountCode;
                        group.GroupAccountName = accountsGroupAccountEntity.GroupAccountName;
                        group.MainAccountId = accountsGroupAccountEntity.MainAccountId;
                        group.SortOrder = accountsGroupAccountEntity.SortOrder;
                        group.IsActive = accountsGroupAccountEntity.IsActive;

                        _unitOfWork.AccountsGroupAccountRepository.Update(group);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteGroupAccount(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var group = _unitOfWork.AccountsGroupAccountRepository.GetById(id);
                    if (group != null)
                    {
                        _unitOfWork.AccountsGroupAccountRepository.Delete(group);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
