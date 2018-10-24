using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices
{
    public class InventoryItemServices: IInventoryItem
    {

        private readonly IUnitOfWork _unitOfWork;

        public InventoryItemServices(IUnitOfWork unitOfWork)
        {
            //pre instantiated object on UnitOfWork
            _unitOfWork = unitOfWork;
        }

        public InventoryItemServices()
        {

        }


        public InventoryItemEntity GetItemById(int id)
        {
            var item = _unitOfWork.InventoryItemRepository.GetById(id);
            if (item != null)
            {
                Mapper.CreateMap<InventoryItem, InventoryItemEntity>();
                var itemModel = Mapper.Map<InventoryItem, InventoryItemEntity>(item);
                return itemModel;
            }
            return null;
        }

        public IEnumerable<InventoryItemEntity> GetAllItems()
        {
            var items = _unitOfWork.InventoryItemRepository.GetAll().ToList();
            if (items.Any())
            {
                Mapper.CreateMap<InventoryItem, InventoryItemEntity>();
                var itemsModel = Mapper.Map<List<InventoryItem>, List<InventoryItemEntity>>(items);
                return itemsModel;
            }
            return null;
        }

        public int CreateInventoryItem(InventoryItemEntity inventoryItem)
        {
            using(var scop= new TransactionScope())
            {
                var item = new InventoryItem
                {
                    ItemName=inventoryItem.ItemName,
                    ItemCode=inventoryItem.ItemCode,
                    ItemDescription=inventoryItem.ItemDescription,
                    PackQuantity=inventoryItem.PackQuantity,
                    UnitPurchasePrice=inventoryItem.UnitPurchasePrice,
                    UnitSalePrice=inventoryItem.UnitSalePrice,
                    IsVat=inventoryItem.IsVat,
                    StockMaxLevel=inventoryItem.StockMaxLevel,
                    StoctNormalLevel=inventoryItem.StoctNormalLevel,
                    StockMinLevel=inventoryItem.StockMinLevel,
                    ItemImagePath=inventoryItem.ItemImagePath,
                    ItemUnitId=inventoryItem.ItemUnitId,
                    ItemGroupId=inventoryItem.ItemGroupId,
                    ItemCategoryId=inventoryItem.ItemCategoryId,
                    IsActive=inventoryItem.IsActive
                };
                _unitOfWork.InventoryItemRepository.Insert(item);
                _unitOfWork.Save();
                scop.Complete();
                return item.Id;
            }
        }

        public bool UpdateInventoryItem(int id, InventoryItemEntity inventoryItem)
        {
            var success = false;
            if (inventoryItem != null)
            {
                using (var scope = new TransactionScope())
                {
                    var item = _unitOfWork.InventoryItemRepository.GetById(id);
                    if (item != null)
                    {
                        item.ItemName = inventoryItem.ItemName;
                        item.ItemCode = inventoryItem.ItemCode;
                        item.ItemDescription = inventoryItem.ItemDescription;
                        item.PackQuantity = inventoryItem.PackQuantity;
                        item.UnitPurchasePrice = inventoryItem.UnitPurchasePrice;
                        item.UnitSalePrice = inventoryItem.UnitSalePrice;
                        item.IsVat = inventoryItem.IsVat;
                        item.StockMaxLevel = inventoryItem.StockMaxLevel;
                        item.StoctNormalLevel = inventoryItem.StoctNormalLevel;
                        item.StockMinLevel = inventoryItem.StockMinLevel;
                        item.ItemImagePath = inventoryItem.ItemImagePath;
                        item.ItemUnitId = inventoryItem.ItemUnitId;
                        item.ItemGroupId = inventoryItem.ItemGroupId;
                        item.ItemCategoryId = inventoryItem.ItemCategoryId;
                        item.IsActive = inventoryItem.IsActive;

                        _unitOfWork.InventoryItemRepository.Update(item);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteInventoryItem(int id)
        {
            var success = false;
            if (id > 0)
            {
                using(var scope=new TransactionScope())
                {
                    var item = _unitOfWork.InventoryItemRepository.GetById(id);
                    if (item != null)
                    {
                        _unitOfWork.InventoryItemRepository.Delete(item);
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


