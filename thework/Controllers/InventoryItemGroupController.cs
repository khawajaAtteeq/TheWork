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
    public class InventoryItemGroupController : ApiController
    {


        #region Call service

        private readonly IInventoryItemGroupServices _inventoryItemGroupServices;

        public InventoryItemGroupController(IInventoryItemGroupServices inventoryItemGroupServices)
        {
            //In this case when the constructor of the controller is called, 
            //It will be served with pre-instantiated service instance, 
            //    and does not need to create an instance of the service,
            //our unity container did the job of object creation.
            _inventoryItemGroupServices = inventoryItemGroupServices;
        }

        readonly IInventoryItemGroupServices inventoryItemGroupServices = new InventoryItemGroupServices();

        public InventoryItemGroupController()
        {
            _inventoryItemGroupServices = inventoryItemGroupServices;
        }

        #endregion

        #region Get Method
        // GET api/product
#pragma warning disable 618
        [Queryable]
        //[ApiAuthenticationFilter(true)]
        [Route("AllItemGroups")]
        [Route("All")]

        public HttpResponseMessage Get()
        {
            try
            {
                var item = _inventoryItemGroupServices.GetAllItemGroups();
                var itemEntities = item as List<InventoryItemGroupEntity> ?? item.ToList();
                if (itemEntities.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, itemEntities);
                }
                // return Request.CreateResponse(HttpStatusCode.NotFound, "Nothing Found!");
                throw new ApiDataException(1000, "No Item Group Found", HttpStatusCode.NotFound);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Get By Id
        // GET api/product/5
        [Route("ItemGroupid/{id?}")]
        [Route("particularItemGroup/{id?}")]
        [Route("myItemGroup/{id:range(1, 3)}")]
        public HttpResponseMessage Get(int id)
        {
            if (id >0)
            {
                var item = _inventoryItemGroupServices.GetItemGroupById(id);
                if (item != null)
                    return Request.CreateResponse(HttpStatusCode.OK, item);

                throw new ApiDataException(1001, "No item group found for this id.", HttpStatusCode.NotFound);
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
        public int Post([FromBody] InventoryItemGroupEntity inventoryItemGroupEntity)
        {
            try
            {
                return _inventoryItemGroupServices.CreateItemGroup(inventoryItemGroupEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Update or PUT
        // PUT api/product/5
        [Route("Update/ItemGroupId/{id}")]
        [Route("Modify/ItemGroupId/{id}")]
        [HttpPut]
        public bool Put(int id, [FromBody] InventoryItemGroupEntity inventoryItemGroupEntity)
        {
            try
            {
                if (id > 0)
                {
                    return _inventoryItemGroupServices.UpdateItemGroup(id, inventoryItemGroupEntity);
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
        [Route("Remove/ItemGroupId/{id}")]
        [Route("Clear/ItemGroupId/{id}")]
        [Route("Delete/ItemGroupId/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var isSuccess = _inventoryItemGroupServices.DeleteItemGroup(id);
                    if (isSuccess)
                    {
                        return true;
                    }
                    throw new ApiDataException(1002, "Item Group does not exist!", HttpStatusCode.NotFound);
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

        #region Call service

        #endregion
    }
}
