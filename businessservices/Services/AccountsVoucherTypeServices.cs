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
    public class AccountsVoucherTypeServices : IAccountsVoucherType
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountsVoucherTypeServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AccountsVoucherTypeServices()
        {
        }

        public AccountsVoucherTypeEntity GetVoucherTypeById(int id)
        {
            var type = _unitOfWork.AccountsVoucherTypeRepository.GetById(id);
            if (type != null)
            {
                Mapper.CreateMap<AccountsVoucherType, AccountsVoucherTypeEntity>();
                var typeModel = Mapper.Map<AccountsVoucherType, AccountsVoucherTypeEntity>(type);
                return typeModel;
            }
            return null;
        }

        public IEnumerable<AccountsVoucherTypeEntity> GetAllVoucherType()
        {
            var type = _unitOfWork.AccountsVoucherTypeRepository.GetAll().ToList();
            if (type != null)
            {
                Mapper.CreateMap<AccountsVoucherType, AccountsVoucherTypeEntity>();
                var typeModel = Mapper.Map<List<AccountsVoucherType>, List<AccountsVoucherTypeEntity>>(type);
                return typeModel;
            }
            return null;
        }

        public int CreateVoucherType(AccountsVoucherTypeEntity accountsVoucherTypeEntity)
        {
            using (var scope = new TransactionScope())
            {
                var type = new AccountsVoucherType
                {
                    VoucherTypeCode = accountsVoucherTypeEntity.VoucherTypeCode,
                    VoucherTypeName = accountsVoucherTypeEntity.VoucherTypeName,
                    SortOrder = accountsVoucherTypeEntity.SortOrder,
                    IsActive = accountsVoucherTypeEntity.IsActive
                };
                _unitOfWork.AccountsVoucherTypeRepository.Insert(type);
                _unitOfWork.Save();
                scope.Complete();
                return type.Id;
            }
        }

        public bool UpdateVoucherType(int id, AccountsVoucherTypeEntity accountsVoucherTypeEntity)
        {
            var success = false;
            if (accountsVoucherTypeEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var type = _unitOfWork.AccountsVoucherTypeRepository.GetById(id);
                    if (type != null)
                    {
                        type.VoucherTypeCode = accountsVoucherTypeEntity.VoucherTypeCode;
                        type.VoucherTypeName = accountsVoucherTypeEntity.VoucherTypeName;
                        type.SortOrder = accountsVoucherTypeEntity.SortOrder;
                        type.IsActive = accountsVoucherTypeEntity.IsActive;
                    }
                    _unitOfWork.AccountsVoucherTypeRepository.Update(type);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                }
            }
            return success;
        }

        public bool DeleteVoucherType(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var type = _unitOfWork.AccountsVoucherTypeRepository.GetById(id);
                    if (type != null)
                    {
                        _unitOfWork.AccountsVoucherTypeRepository.Delete(type);
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
