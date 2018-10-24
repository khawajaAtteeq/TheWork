using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System.Transactions;


namespace BusinessServices
{
    public class InventoryItemGroupServices : IInventoryItemGroupServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryItemGroupServices(IUnitOfWork unitOfWork)
        {
            //pre instantiated object on UnitOfWork
            _unitOfWork = unitOfWork;
        }

        public InventoryItemGroupServices()
        {

        }

        public int CreateItemGroup(InventoryItemGroupEntity inventoryDefineItemGroupEntity)
        {
            using(var scope= new TransactionScope())
            {
                var group = new InventoryItemGroup
                {
                    ItemGroupCode=inventoryDefineItemGroupEntity.ItemGroupCode,
                    ItemGroupName=inventoryDefineItemGroupEntity.ItemGroupName,
                    SortOrder=inventoryDefineItemGroupEntity.SortOrder,
                    IsActive=inventoryDefineItemGroupEntity.IsActive
                };
                _unitOfWork.InventoryItemGroupRepository.Insert(group);
                _unitOfWork.Save();
                scope.Complete();
                return group.Id;
            }
        }

        public bool DeleteItemGroup(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var group = _unitOfWork.InventoryItemGroupRepository.GetById(id);
                    if (group != null)
                    {
                        _unitOfWork.InventoryItemGroupRepository.Delete(group);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public IEnumerable<InventoryItemGroupEntity> GetAllItemGroups()
        {
            var group = _unitOfWork.InventoryItemGroupRepository.GetAll().ToList();
            if (group.Any())
            {
                Mapper.CreateMap<InventoryItemGroup, InventoryItemGroupEntity>();
                var groupModel = Mapper.Map<List<InventoryItemGroup>, List<InventoryItemGroupEntity>>(group);
                return groupModel;
            }
            return null;
        }

        public InventoryItemGroupEntity GetItemGroupById(int groupId)
        {
            var group = _unitOfWork.InventoryItemGroupRepository.GetById(groupId);
            if(group != null)
            {
                Mapper.CreateMap<InventoryItemGroup, InventoryItemGroupEntity>();
                var groupModel = Mapper.Map<InventoryItemGroup, InventoryItemGroupEntity>(group);
                return groupModel;
            }
            return null;
        }

        public bool UpdateItemGroup(int id, InventoryItemGroupEntity inventoryDefineItemGroupEntity)
        {
            var success = false;
            if (inventoryDefineItemGroupEntity!=null)
            {
                using(var scope=new TransactionScope())
                {
                    var group = _unitOfWork.InventoryItemGroupRepository.GetById(id);
                    if (group != null)
                    {
                        group.ItemGroupCode = inventoryDefineItemGroupEntity.ItemGroupCode;
                        group.ItemGroupName = inventoryDefineItemGroupEntity.ItemGroupName;
                        group.SortOrder = inventoryDefineItemGroupEntity.SortOrder;
                        group.IsActive = inventoryDefineItemGroupEntity.IsActive;

                        _unitOfWork.InventoryItemGroupRepository.Update(group);
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
