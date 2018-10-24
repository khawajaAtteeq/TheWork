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
    public class AccountsDetailAccountServices: IAccountsDetailAccount
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountsDetailAccountServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AccountsDetailAccountServices()
        {
        }

        public AccountsDetailAccountEntity GetDetailAccountById(int id)
        {
            var detail = _unitOfWork.AccountsDetailAccountRepository.GetById(id);
            if (detail != null)
            {
                Mapper.CreateMap<AccountsDetailAccount, AccountsDetailAccountEntity>();
                var detailModel=Mapper.Map<AccountsDetailAccount, AccountsDetailAccountEntity>(detail);
                return detailModel;
            }
            return null;
        }

        public IEnumerable<AccountsDetailAccountEntity> GetAllDetailAccount()
        {
            var detail = _unitOfWork.AccountsDetailAccountRepository.GetAll().ToList();
            if (detail != null)
            {
                Mapper.CreateMap<AccountsDetailAccount, AccountsDetailAccountEntity>();
                var detailModel = Mapper.Map<List<AccountsDetailAccount>, List<AccountsDetailAccountEntity>>(detail);
                return detailModel;
            }
            return null;
        }

        public int CreateDetailAccount(AccountsDetailAccountEntity accountsDetailAccountEntity)
        {
            using(var scope=new TransactionScope())
            {
                var detail = new AccountsDetailAccount
                {
                    DetailAccountCode=accountsDetailAccountEntity.DetailAccountCode,
                    DetailAccountName=accountsDetailAccountEntity.DetailAccountName,
                    HeadAccountId=accountsDetailAccountEntity.HeadAccountId,
                    SortOrder=accountsDetailAccountEntity.SortOrder,
                    IsActive=accountsDetailAccountEntity.IsActive
                };
                _unitOfWork.AccountsDetailAccountRepository.Insert(detail);
                _unitOfWork.Save();
                scope.Complete();
                return detail.Id;
            }
        }

        public bool UpdateDetailAccount(int id, AccountsDetailAccountEntity accountsDetailAccountEntity)
        {
            var success = false;
            if (accountsDetailAccountEntity != null)
            {
                var detail = _unitOfWork.AccountsDetailAccountRepository.GetById(id);
                if (detail != null)
                {
                    using(var scope= new TransactionScope())
                    {
                        detail.DetailAccountCode = accountsDetailAccountEntity.DetailAccountCode;
                        detail.DetailAccountName = accountsDetailAccountEntity.DetailAccountName;
                        detail.HeadAccountId = accountsDetailAccountEntity.HeadAccountId;
                        detail.SortOrder = accountsDetailAccountEntity.SortOrder;
                        detail.IsActive = accountsDetailAccountEntity.IsActive;

                        _unitOfWork.AccountsDetailAccountRepository.Update(detail);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteDetailAccount(int id)
        {
            var success = false;
            if (id > 0)
            {
                using(var scope= new TransactionScope())
                {
                    var detail = _unitOfWork.AccountsDetailAccountRepository.GetById(id);
                    if (detail != null)
                    {
                        _unitOfWork.AccountsDetailAccountRepository.Delete(detail);
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
