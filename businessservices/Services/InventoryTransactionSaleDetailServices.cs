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
    public class InventoryTransactionSaleDetailServices: IInventoryTransactionSaleDetail
    {
        private readonly IUnitOfWork _unitOfWork;
        public InventoryTransactionSaleDetailServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public InventoryTransactionSaleDetailServices()
        {
        }

        public InventoryTransactionSaleDetailEntity GetInventoryTransactionSaleDetailById(int id)
        {
            var sale = _unitOfWork.InventoryTransactionSaleDetailRepository.GetById(id);
            if (sale != null)
            {
                Mapper.CreateMap<InventoryTransactionSaleDetail, InventoryTransactionSaleDetailEntity>();
                var saleModel = Mapper.Map<InventoryTransactionSaleDetail, InventoryTransactionSaleDetailEntity>(sale);
                return saleModel;
            }
            return null;
        }

        public IEnumerable<InventoryTransactionSaleDetailEntity> GetAllInventoryTransactionSaleDetails()
        {
            var sale = _unitOfWork.InventoryTransactionSaleDetailRepository.GetAll().ToList();
            if (sale != null)
            {
                Mapper.CreateMap<InventoryTransactionSaleDetail, InventoryTransactionSaleDetailEntity>();
                var saleModel = Mapper.Map<List<InventoryTransactionSaleDetail>, List<InventoryTransactionSaleDetailEntity>>(sale);
                return saleModel;
            }
            return null;
        }

        public int CreateInventoryTransactionSaleDetail(InventoryTransactionSaleDetailEntity inventoryTransactionSaleDetailEntity)
        {
            using(var scope= new TransactionScope())
            {
                var sale = new InventoryTransactionSaleDetail
                {
                    Comments=inventoryTransactionSaleDetailEntity.Comments,
                    DiscountAmount=inventoryTransactionSaleDetailEntity.DiscountAmount,
                    DiscountPercentage=inventoryTransactionSaleDetailEntity.DiscountPercentage,
                    ItemId=inventoryTransactionSaleDetailEntity.ItemId,
                    ItemUnitId=inventoryTransactionSaleDetailEntity.ItemUnitId,
                    Quantity=inventoryTransactionSaleDetailEntity.Quantity,
                    SaleAmount=inventoryTransactionSaleDetailEntity.SaleAmount,
                    SaleId=inventoryTransactionSaleDetailEntity.SaleId,
                    UnitPrice=inventoryTransactionSaleDetailEntity.UnitPrice,
                    Vat=inventoryTransactionSaleDetailEntity.Vat,
                    VatPercentage=inventoryTransactionSaleDetailEntity.VatPercentage
                };
                _unitOfWork.InventoryTransactionSaleDetailRepository.Insert(sale);
                _unitOfWork.Save();
                scope.Complete();
                return sale.Id;
            }
        }

        public bool UpdateInventoryTransactionSaleDetail(int id,InventoryTransactionSaleDetailEntity inventoryTransactionSaleDetailEntity)
        {
            var success = false;
            if (inventoryTransactionSaleDetailEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var sale = _unitOfWork.InventoryTransactionSaleDetailRepository.GetById(id);
                    if (sale != null)
                    {
                        sale.Comments = inventoryTransactionSaleDetailEntity.Comments;
                        sale.DiscountAmount = inventoryTransactionSaleDetailEntity.DiscountAmount;
                        sale.DiscountPercentage = inventoryTransactionSaleDetailEntity.DiscountPercentage;
                        sale.ItemId = inventoryTransactionSaleDetailEntity.ItemId;
                        sale.ItemUnitId = inventoryTransactionSaleDetailEntity.ItemUnitId;
                        sale.Quantity = inventoryTransactionSaleDetailEntity.Quantity;
                        sale.SaleAmount = inventoryTransactionSaleDetailEntity.SaleAmount;
                        sale.SaleId = inventoryTransactionSaleDetailEntity.SaleId;
                        sale.UnitPrice = inventoryTransactionSaleDetailEntity.UnitPrice;
                        sale.Vat = inventoryTransactionSaleDetailEntity.Vat;
                        sale.VatPercentage = inventoryTransactionSaleDetailEntity.VatPercentage;

                        _unitOfWork.InventoryTransactionSaleDetailRepository.Update(sale);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteInventoryTransactionSaleDetail(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var sale = _unitOfWork.InventoryTransactionSaleDetailRepository.GetById(id);
                    if (sale != null)
                    {
                        _unitOfWork.InventoryTransactionSaleDetailRepository.Delete(sale);
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
