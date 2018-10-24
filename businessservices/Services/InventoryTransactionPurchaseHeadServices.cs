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
    public class InventoryTransactionPurchaseHeadServices: IInventoryTransactionPurchaseHead
    {
        private readonly IUnitOfWork _unitOfWork;
        public InventoryTransactionPurchaseHeadServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public InventoryTransactionPurchaseHeadServices()
        {
        }

        public InventoryTransactionPurchaseHeadEntity GetInventoryTransactionPurchaseHeadById(int id)
        {
            var purchase = _unitOfWork.InventoryTransactionPurchaseHeadRepository.GetById(id);
            if (purchase != null)
            {
                Mapper.CreateMap<InventoryTransactionPurchaseHead, InventoryTransactionPurchaseHeadEntity>();
                var purchaseModel = Mapper.Map<InventoryTransactionPurchaseHead, InventoryTransactionPurchaseHeadEntity>(purchase);
                return purchaseModel;
            }
            return null;
        }

        public IEnumerable<InventoryTransactionPurchaseHeadEntity> GetAllInventoryTransactionPurchaseHeads()
        {
            var purchase = _unitOfWork.InventoryTransactionPurchaseHeadRepository.GetAll().ToList();
            if (purchase != null)
            {
                Mapper.CreateMap<InventoryTransactionPurchaseHead, InventoryTransactionPurchaseHeadEntity>();
                var purchaseModel = Mapper.Map<List<InventoryTransactionPurchaseHead>, List<InventoryTransactionPurchaseHeadEntity>>(purchase);
                return purchaseModel;
            }
            return null;
        }

        public int CreateInventoryTransactionPurchaseHead(InventoryTransactionPurchaseHeadEntity inventoryTransactionPurchaseHeadEntity)
        {
            using (var scope = new TransactionScope())
            {
                var purchase = new InventoryTransactionPurchaseHead
                {
                    CheckedDate=inventoryTransactionPurchaseHeadEntity.CheckedDate,
                    CheckedUserId=inventoryTransactionPurchaseHeadEntity.CheckedUserId,
                    EntryDate=inventoryTransactionPurchaseHeadEntity.EntryDate,
                    EntryUserId=inventoryTransactionPurchaseHeadEntity.EntryUserId,
                    PostedDate=inventoryTransactionPurchaseHeadEntity.PostedDate,
                    PostedUserId=inventoryTransactionPurchaseHeadEntity.PostedUserId,
                    PurchaseDate=inventoryTransactionPurchaseHeadEntity.PurchaseDate,
                    PurchaseNo=inventoryTransactionPurchaseHeadEntity.PurchaseNo,
                    PurchaseOrderId=inventoryTransactionPurchaseHeadEntity.PurchaseOrderId,
                    PurchaseStatus=inventoryTransactionPurchaseHeadEntity.PurchaseStatus,
                    PurchaseTotalAmount=inventoryTransactionPurchaseHeadEntity.PurchaseTotalAmount,
                    Remarks=inventoryTransactionPurchaseHeadEntity.Remarks,
                    VendorId=inventoryTransactionPurchaseHeadEntity.VendorId
                };
                _unitOfWork.InventoryTransactionPurchaseHeadRepository.Insert(purchase);
                _unitOfWork.Save();
                scope.Complete();
                return purchase.Id;
            }
        }

        public bool UpdateInventoryTransactionPurchaseHead(int id, InventoryTransactionPurchaseHeadEntity inventoryTransactionPurchaseHeadEntity)
        {
            var success = false;
            if (inventoryTransactionPurchaseHeadEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var purchase = _unitOfWork.InventoryTransactionPurchaseHeadRepository.GetById(id);
                    if (purchase != null)
                    {
                        purchase.CheckedDate = inventoryTransactionPurchaseHeadEntity.CheckedDate;
                        purchase.CheckedUserId = inventoryTransactionPurchaseHeadEntity.CheckedUserId;
                        purchase.EntryDate = inventoryTransactionPurchaseHeadEntity.EntryDate;
                        purchase.EntryUserId = inventoryTransactionPurchaseHeadEntity.EntryUserId;
                        purchase.PostedDate = inventoryTransactionPurchaseHeadEntity.PostedDate;
                        purchase.PostedUserId = inventoryTransactionPurchaseHeadEntity.PostedUserId;
                        purchase.PurchaseDate = inventoryTransactionPurchaseHeadEntity.PurchaseDate;
                        purchase.PurchaseNo = inventoryTransactionPurchaseHeadEntity.PurchaseNo;
                        purchase.PurchaseOrderId = inventoryTransactionPurchaseHeadEntity.PurchaseOrderId;
                        purchase.PurchaseStatus = inventoryTransactionPurchaseHeadEntity.PurchaseStatus;
                        purchase.PurchaseTotalAmount = inventoryTransactionPurchaseHeadEntity.PurchaseTotalAmount;
                        purchase.Remarks = inventoryTransactionPurchaseHeadEntity.Remarks;
                        purchase.VendorId = inventoryTransactionPurchaseHeadEntity.VendorId;

                        _unitOfWork.InventoryTransactionPurchaseHeadRepository.Update(purchase);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteInventoryTransactionPurchaseHead(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var purchase = _unitOfWork.InventoryTransactionPurchaseHeadRepository.GetById(id);
                    if (purchase != null)
                    {
                        _unitOfWork.InventoryTransactionPurchaseHeadRepository.Delete(purchase);
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
