using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices
{
    public class InventoryItemCategoryServices : IInventoryItemCategory
    {

        private readonly IUnitOfWork _unitOfWork;

        public InventoryItemCategoryServices(IUnitOfWork unitOfWork)
        {
            // pre instatiate object on uow
            _unitOfWork = unitOfWork;
        }

        public InventoryItemCategoryServices()
        {

        }
        public int CreateItemCategory(InventoryItemCategoryEntity inventoryItemCategory)
        {
            using (var scope = new TransactionScope())
            {
                var category = new InventoryItemCategory
                {
                    ItemCategoryCode= inventoryItemCategory.ItemCategoryCode,
                    ItemCategoryName= inventoryItemCategory.ItemCategoryName,
                    ItemGroupID=inventoryItemCategory.ItemGroupID,
                    SaleAccountID=inventoryItemCategory.SaleAccountID,
                    PurchaseAccountID=inventoryItemCategory.PurchaseAccountID,
                    SortOrder=inventoryItemCategory.SortOrder,
                    IsActive=inventoryItemCategory.IsActive
                };
                _unitOfWork.InventoryItemCategoryRepository.Insert(category);
                _unitOfWork.Save();
                scope.Complete();
                return category.Id;
            }
        }

        public bool DeleteItemCatygory(int id)
        {
            var success = false;
            if (id > 0)
            {
                using(var scope= new TransactionScope())
                {
                    var category = _unitOfWork.InventoryItemCategoryRepository.GetById(id);
                    if (category != null)
                    {
                        _unitOfWork.InventoryItemCategoryRepository.Delete(category);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public IEnumerable<InventoryItemCategoryEntity> GetAllItemCategory()
        {
            var category = _unitOfWork.InventoryItemCategoryRepository.GetAll().ToList();
            if (category.Any())
            {
                Mapper.CreateMap<InventoryItemCategory, InventoryItemCategoryEntity>();
                var catModel = Mapper.Map<List<InventoryItemCategory>, List<InventoryItemCategoryEntity>>(category);
                return catModel;
            }
            return null;
        }

        public InventoryItemCategoryEntity GetItemCategoryById(int id)
        {
            var category = _unitOfWork.InventoryItemCategoryRepository.GetById(id);
            if (category != null)
            {
                Mapper.CreateMap<InventoryItemCategory, InventoryItemCategoryEntity>();
                var catModel = Mapper.Map<InventoryItemCategory, InventoryItemCategoryEntity>(category);
                return catModel;
            }
            return null;
        }

        public bool UpdateItemCategory(int id, InventoryItemCategoryEntity inventoryItemCategory)
        {
            var success = false;
            if (inventoryItemCategory != null)
            {
                using (var scope = new TransactionScope())
                {
                    var category = _unitOfWork.InventoryItemCategoryRepository.GetById(id);
                    if (category != null)
                    {
                        category.ItemCategoryCode = inventoryItemCategory.ItemCategoryCode;
                        category.ItemCategoryName = inventoryItemCategory.ItemCategoryName;
                        category.ItemGroupID = inventoryItemCategory.ItemGroupID;
                        category.SaleAccountID = inventoryItemCategory.SaleAccountID;
                        category.PurchaseAccountID = inventoryItemCategory.PurchaseAccountID;
                        category.SortOrder = inventoryItemCategory.SortOrder;
                        category.IsActive = inventoryItemCategory.IsActive;

                        _unitOfWork.InventoryItemCategoryRepository.Update(category);
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
