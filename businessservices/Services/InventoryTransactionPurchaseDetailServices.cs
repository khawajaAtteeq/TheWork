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
    public class InventoryTransactionPurchaseDetailServices: IInventoryTransactionPurchaseDetail
    {
        private readonly IUnitOfWork _unitOfWork;
        public InventoryTransactionPurchaseDetailServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public InventoryTransactionPurchaseDetailServices()
        {
        }

        public InventoryTransactionPurchaseDetailEntity GetInventoryTransactionPurchaseDetailById(int id)
        {
            var purchase = _unitOfWork.InventoryTransactionPurchaseDetailRepository.GetById(id);
            if (purchase != null)
            {
                Mapper.CreateMap<InventoryTransactionPurchaseDetail, InventoryTransactionPurchaseDetailEntity>();
                var purchaseModel = Mapper.Map<InventoryTransactionPurchaseDetail, InventoryTransactionPurchaseDetailEntity>(purchase);
                return purchaseModel;
            }
            return null;
        }

        public IEnumerable<InventoryTransactionPurchaseDetailEntity> GetAllInventoryTransactionPurchaseDetails()
        {
            var purchase = _unitOfWork.InventoryTransactionPurchaseDetailRepository.GetAll().ToList();
            if (purchase != null)
            {
                Mapper.CreateMap<InventoryTransactionPurchaseDetail, InventoryTransactionPurchaseDetailEntity>();
                var purchaseModel = Mapper.Map<List<InventoryTransactionPurchaseDetail>, List<InventoryTransactionPurchaseDetailEntity>>(purchase);
                return purchaseModel;
            }
            return null;
        }

        public int CreateInventoryTransactionPurchaseDetail(InventoryTransactionPurchaseDetailEntity inventoryTransactionPurchaseDetailEntity)
        {
            using (var scope = new TransactionScope())
            {
                var purchase = new InventoryTransactionPurchaseDetail
                {
                    Comments=inventoryTransactionPurchaseDetailEntity.Comments,
                    DiscountAmount=inventoryTransactionPurchaseDetailEntity.DiscountAmount,
                    DiscountPercentage=inventoryTransactionPurchaseDetailEntity.DiscountPercentage,
                    ItemId=inventoryTransactionPurchaseDetailEntity.ItemId,
                    ItemUnitId=inventoryTransactionPurchaseDetailEntity.ItemUnitId,
                    PurchaseAmount=inventoryTransactionPurchaseDetailEntity.PurchaseAmount,
                    PurchaseId=inventoryTransactionPurchaseDetailEntity.PurchaseId,
                    Quantity=inventoryTransactionPurchaseDetailEntity.Quantity,
                    UnitPrice=inventoryTransactionPurchaseDetailEntity.UnitPrice,
                    Vat=inventoryTransactionPurchaseDetailEntity.Vat,
                    VatPercentage=inventoryTransactionPurchaseDetailEntity.VatPercentage
                };
                _unitOfWork.InventoryTransactionPurchaseDetailRepository.Insert(purchase);
                _unitOfWork.Save();
                scope.Complete();
                return purchase.Id;
            }
        }

        public bool UpdateInventoryTransactionPurchaseDetail(int id, InventoryTransactionPurchaseDetailEntity inventoryTransactionPurchaseDetailEntity)
        {
            var success = false;
            if (inventoryTransactionPurchaseDetailEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var purchase = _unitOfWork.InventoryTransactionPurchaseDetailRepository.GetById(id);
                    if (purchase != null)
                    {
                        purchase.Comments = inventoryTransactionPurchaseDetailEntity.Comments;
                        purchase.DiscountAmount = inventoryTransactionPurchaseDetailEntity.DiscountAmount;
                        purchase.DiscountPercentage = inventoryTransactionPurchaseDetailEntity.DiscountPercentage;
                        purchase.ItemId = inventoryTransactionPurchaseDetailEntity.ItemId;
                        purchase.ItemUnitId = inventoryTransactionPurchaseDetailEntity.ItemUnitId;
                        purchase.PurchaseAmount = inventoryTransactionPurchaseDetailEntity.PurchaseAmount;
                        purchase.PurchaseId = inventoryTransactionPurchaseDetailEntity.PurchaseId;
                        purchase.Quantity = inventoryTransactionPurchaseDetailEntity.Quantity;
                        purchase.UnitPrice = inventoryTransactionPurchaseDetailEntity.UnitPrice;
                        purchase.Vat = inventoryTransactionPurchaseDetailEntity.Vat;
                        purchase.VatPercentage = inventoryTransactionPurchaseDetailEntity.VatPercentage;

                        _unitOfWork.InventoryTransactionPurchaseDetailRepository.Update(purchase);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteInventoryTransactionPurchaseDetail(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var purchase = _unitOfWork.InventoryTransactionPurchaseDetailRepository.GetById(id);
                    if (purchase != null)
                    {
                        _unitOfWork.InventoryTransactionPurchaseDetailRepository.Delete(purchase);
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
