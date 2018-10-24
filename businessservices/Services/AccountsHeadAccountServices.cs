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
    public class AccountsHeadAccountServices: IAccountsHeadAccount
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountsHeadAccountServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AccountsHeadAccountServices()
        {

        }

        public AccountsHeadAccountEntity GetAccountsHeadById(int id)
        {
            var head = _unitOfWork.AccountsHeadAccountRepository.GetById(id);
            if (head != null)
            {
                Mapper.CreateMap<AccountsHeadAccount, AccountsHeadAccountEntity>();
                var headModel=Mapper.Map<AccountsHeadAccount, AccountsHeadAccountEntity>(head);
                return headModel;
            }
            return null;
        }

        public IEnumerable<AccountsHeadAccountEntity> GetAllAccountsHeads()
        {
            var head = _unitOfWork.AccountsHeadAccountRepository.GetAll();
            if (head != null)
            {
                Mapper.CreateMap<AccountsHeadAccount, AccountsHeadAccountEntity>();
                var headModel = Mapper.Map<List<AccountsHeadAccount>, List<AccountsHeadAccountEntity>>(head);
                return headModel;
            }
            return null;
        }

        public int CreateHeadAccount(AccountsHeadAccountEntity accountsHeadAccountEntity)
        {
            using(var scope= new TransactionScope())
            {
                var head = new AccountsHeadAccount
                {
                    HeadAccountCode=accountsHeadAccountEntity.HeadAccountCode,
                    HeadAccountName=accountsHeadAccountEntity.HeadAccountName,
                    BalanceSheetNoteId=accountsHeadAccountEntity.BalanceSheetNoteId,
                    GroupAccountId=accountsHeadAccountEntity.GroupAccountId,
                    ProfitLoseNoteId=accountsHeadAccountEntity.ProfitLoseNoteId,
                    SortOrder=accountsHeadAccountEntity.SortOrder,
                    IsActive=accountsHeadAccountEntity.IsActive
                };
                _unitOfWork.AccountsHeadAccountRepository.Insert(head);
                _unitOfWork.Save();
                scope.Complete();
                return head.Id;
            }
        }

        public bool UpdateHeadAccount(int id, AccountsHeadAccountEntity accountsHeadAccountEntity)
        {
            var success = false;
            if (accountsHeadAccountEntity != null)
            {
                using(var scope= new TransactionScope())
                {
                    var head = _unitOfWork.AccountsHeadAccountRepository.GetById(id);
                    if (head != null)
                    {
                        head.HeadAccountCode = accountsHeadAccountEntity.HeadAccountCode;
                        head.HeadAccountName = accountsHeadAccountEntity.HeadAccountName;
                        head.BalanceSheetNoteId = accountsHeadAccountEntity.BalanceSheetNoteId;
                        head.GroupAccountId = accountsHeadAccountEntity.GroupAccountId;
                        head.ProfitLoseNoteId = accountsHeadAccountEntity.ProfitLoseNoteId;
                        head.SortOrder = accountsHeadAccountEntity.SortOrder;
                        head.IsActive = accountsHeadAccountEntity.IsActive;

                        _unitOfWork.AccountsHeadAccountRepository.Update(head);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteHeadAccount(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var head = _unitOfWork.AccountsHeadAccountRepository.GetById(id);
                    if (head != null)
                    {
                        _unitOfWork.AccountsHeadAccountRepository.Delete(head);
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
