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
    public class AccountsTransactionVoucherHeadServices: IAccountsTransactionVoucherHead
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountsTransactionVoucherHeadServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AccountsTransactionVoucherHeadServices()
        {
        }

        public AccountsTransactionVoucherHeadEntity GetAccountsVoucherHeadById(int id)
        {
            var head = _unitOfWork.AccountsTransactionVoucherHeadRepository.GetById(id);
            if (head != null)
            {
                Mapper.CreateMap<AccountsTransactionVoucherHead, AccountsTransactionVoucherHeadEntity>();
                var headModel = Mapper.Map<AccountsTransactionVoucherHead, AccountsTransactionVoucherHeadEntity>(head);
                return headModel;
            }
            return null;
        }

        public IEnumerable<AccountsTransactionVoucherHeadEntity> GetAllAccountsVoucherHeads()
        {
            var head = _unitOfWork.AccountsTransactionVoucherHeadRepository.GetAll().ToList();
            if (head != null)
            {
                Mapper.CreateMap<AccountsTransactionVoucherHead, AccountsTransactionVoucherHeadEntity>();
                var headModel = Mapper.Map<List<AccountsTransactionVoucherHead>, List<AccountsTransactionVoucherHeadEntity>>(head);
                return headModel;
            }
            return null;
        }

        public int CreateTransactionVoucherHead(AccountsTransactionVoucherHeadEntity accountsTransactionVoucherHeadEntity)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateTransactionVoucherHead(AccountsTransactionVoucherHeadEntity accountsTransactionVoucherHeadEntity)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteTransactionVoucherHead(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var detail = _unitOfWork.AccountsTransactionVoucherHeadRepository.GetById(id);
                    if (detail != null)
                    {
                        _unitOfWork.AccountsTransactionVoucherHeadRepository.Delete(detail);
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
