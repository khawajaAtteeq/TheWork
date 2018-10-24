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
    public class InventoryTransactionPurchaseHeadController : ApiController
    {
        #region Call service
        private readonly IInventoryTransactionPurchaseHead _inventoryTransactionPurchaseHead;
        public InventoryTransactionPurchaseHeadController(IInventoryTransactionPurchaseHead inventoryTransactionPurchaseHead)
        {
            _inventoryTransactionPurchaseHead = inventoryTransactionPurchaseHead;
        }
        readonly IInventoryTransactionPurchaseHead inventoryTransactionPurchaseHead = new InventoryTransactionPurchaseHeadServices();
        public InventoryTransactionPurchaseHeadController()
        {
            _inventoryTransactionPurchaseHead = inventoryTransactionPurchaseHead;
        }
        #endregion

        #region Get All

#pragma warning disable CS0618 // Type or member is obsolete
        [Queryable]
#pragma warning restore CS0618 // Type or member is obsolete
        //[ApiAuthenticationFilter(true)]
        [Route("AllTransactionPurchaseHead")]
        [Route("All")]

        public HttpResponseMessage Get()
        {
            try
            {
                var purchase = _inventoryTransactionPurchaseHead.GetAllInventoryTransactionPurchaseHeads();
                var purchaseEntities = purchase as List<InventoryTransactionPurchaseHeadEntity> ?? purchase.ToList();
                if (purchaseEntities.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, purchaseEntities);
                }
                // return Request.CreateResponse(HttpStatusCode.NotFound, "Nothing Found!");
                throw new ApiDataException(1000, "No Purchase Head Found", HttpStatusCode.NotFound);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Get By Id
        // GET api/product/5
        [Route("PurchaseHeadid/{id?}")]
        [Route("particularPurchaseHead/{id?}")]
        [Route("myPurchaseHead/{id:range(1, 3)}")]
        public HttpResponseMessage Get(int id)
        {
            if (id > 0)
            {
                var purchase = _inventoryTransactionPurchaseHead.GetInventoryTransactionPurchaseHeadById(id);
                if (purchase != null)
                    return Request.CreateResponse(HttpStatusCode.OK, purchase);

                throw new ApiDataException(1001, "No Purchase Head found for this id.", HttpStatusCode.NotFound);
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

        #region Post- Create 
        [Route("Create")]
        [Route("Add")]
        [HttpPost]
        public int Post([FromBody] InventoryTransactionPurchaseHeadEntity inventoryTransactionPurchaseHeadEntity)
        {
            try
            {
                return _inventoryTransactionPurchaseHead.CreateInventoryTransactionPurchaseHead(inventoryTransactionPurchaseHeadEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Update or PUT
        // PUT api/product/5
        [Route("Update/PurchaseHeadId/{id}")]
        [Route("Modify/PurchaseHeadId/{id}")]
        [HttpPut]
        public bool Put(int id, [FromBody] InventoryTransactionPurchaseHeadEntity inventoryTransactionPurchaseHeadEntity)
        {
            try
            {
                if (id > 0)
                {
                    return _inventoryTransactionPurchaseHead.UpdateInventoryTransactionPurchaseHead(id, inventoryTransactionPurchaseHeadEntity);
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
        [Route("Remove/PurchaseHeadId/{id}")]
        [Route("Clear/PurchaseHeadId/{id}")]
        [Route("Delete/PurchaseHeadId/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var isSuccess = _inventoryTransactionPurchaseHead.DeleteInventoryTransactionPurchaseHead(id);
                    if (isSuccess)
                    {
                        return true;
                    }
                    throw new ApiDataException(1002, "Purchase Head does not exist!", HttpStatusCode.NotFound);
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
