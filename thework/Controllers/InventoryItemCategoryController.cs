using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices;
using TheWork.Filters;
using TheWork.ErrorHelper;
using TheWork.ActionFilters;
using System.Collections.Generic;
using BusinessServices.Interface;
using BusinessServices.Services;

namespace TheWork.Controllers
{
    public class InventoryItemCategoryController : ApiController
    {
        #region Call service

        private readonly IInventoryItemCategory _inventoryItemCategory;

        public InventoryItemCategoryController(IInventoryItemCategory inventoryItemCategory)
        {
            //In this case when the constructor of the controller is called, 
            //It will be served with pre-instantiated service instance, 
            //    and does not need to create an instance of the service,
            //our unity container did the job of object creation.
            _inventoryItemCategory = inventoryItemCategory;
        }

        readonly IInventoryItemCategory inventoryItemCategory = new InventoryItemCategoryServices();

        public InventoryItemCategoryController()
        {
            _inventoryItemCategory = inventoryItemCategory;
        }

        #endregion

        #region Get Method
        // GET api/product
#pragma warning disable 618
        [Queryable]
        //[ApiAuthenticationFilter(true)]
        [Route("AllItemCategorys")]
        [Route("All")]

        public HttpResponseMessage Get()
        {
            try
            {
                var item = _inventoryItemCategory.GetAllItemCategory();
                var itemEntities = item as List<InventoryItemCategoryEntity> ?? item.ToList();
                if (itemEntities.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, itemEntities);
                }
                // return Request.CreateResponse(HttpStatusCode.NotFound, "Nothing Found!");
                throw new ApiDataException(1000, "No Item Category Found", HttpStatusCode.NotFound);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Get By Id
        // GET api/product/5
        [Route("ItemCategoryid/{id?}")]
        [Route("particularItemCategory/{id?}")]
        [Route("myItemCategory/{id:range(1, 3)}")]
        public HttpResponseMessage Get(int id)
        {
            if (id > 0)
            {
                var item = _inventoryItemCategory.GetItemCategoryById(id);
                if (item != null)
                    return Request.CreateResponse(HttpStatusCode.OK, item);

                throw new ApiDataException(1001, "No item category found for this id.", HttpStatusCode.NotFound);
            }
            throw new ApiException()
            {
                ErrorCode = (int)HttpStatusCode.BadRequest,
                ErrorDescription = "Bad Request..."
            };

            #region with TRY CATCH

            #endregion
        }


        #endregion

        #region Post 
        // POST api/product
        [Route("Create")]
        [Route("Add")]
        [HttpPost]
        public int Post([FromBody] InventoryItemCategoryEntity inventoryItemCategoryEntity)
        {
            try
            {
                return _inventoryItemCategory.CreateItemCategory(inventoryItemCategoryEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Update or PUT
        // PUT api/product/5
        [Route("Update/ItemCategoryId/{id}")]
        [Route("Modify/ItemCategoryId/{id}")]
        [HttpPut]
        public bool Put(int id, [FromBody] InventoryItemCategoryEntity inventoryItemCategoryEntity)
        {
            try
            {
                if (id > 0)
                {
                    return _inventoryItemCategory.UpdateItemCategory(id, inventoryItemCategoryEntity);
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region Delete
        // DELETE api/product/5
        [Route("Remove/ItemCategoryId/{id}")]
        [Route("Clear/ItemCategoryId/{id}")]
        [Route("Delete/ItemCategoryId/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var isSuccess = _inventoryItemCategory.DeleteItemCatygory(id);
                    if (isSuccess)
                    {
                        return true;
                    }
                    throw new ApiDataException(1002, "Item category does not exist!", HttpStatusCode.NotFound);
                    //return _productServices.DeleteProduct(id);
                }
                return false;
            }
            catch (Exception)
            {
                throw new ApiException()
                {
                    ErrorCode = (int)HttpStatusCode.BadRequest,
                    ErrorDescription = "Bad Request..."
                };
            }
        }

        #endregion

    }
}
