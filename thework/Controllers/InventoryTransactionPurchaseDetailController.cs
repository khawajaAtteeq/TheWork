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
    public class InventoryTransactionPurchaseDetailController : ApiController
    {
        #region Call service
        private readonly IInventoryTransactionPurchaseDetail _inventoryTransactionPurchaseDetail;
        public InventoryTransactionPurchaseDetailController(IInventoryTransactionPurchaseDetail inventoryTransactionPurchaseDetail)
        {
            _inventoryTransactionPurchaseDetail = inventoryTransactionPurchaseDetail;
        }
        readonly IInventoryTransactionPurchaseDetail inventoryTransactionPurchaseDetail = new InventoryTransactionPurchaseDetailServices();
        public InventoryTransactionPurchaseDetailController()
        {
            _inventoryTransactionPurchaseDetail = inventoryTransactionPurchaseDetail; 
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
                var purchase = _inventoryTransactionPurchaseDetail.GetAllInventoryTransactionPurchaseDetails();
                var purchaseEntities = purchase as List<InventoryTransactionPurchaseDetailEntity> ?? purchase.ToList();
                if (purchaseEntities.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, purchaseEntities);
                }
                // return Request.CreateResponse(HttpStatusCode.NotFound, "Nothing Found!");
                throw new ApiDataException(1000, "No Purchase Detail Found", HttpStatusCode.NotFound);
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
                var purchase = _inventoryTransactionPurchaseDetail.GetInventoryTransactionPurchaseDetailById(id);
                if (purchase != null)
                    return Request.CreateResponse(HttpStatusCode.OK, purchase);

                throw new ApiDataException(1001, "No Purchase Detail found for this id.", HttpStatusCode.NotFound);
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
        public int Post([FromBody] InventoryTransactionPurchaseDetailEntity inventoryTransactionPurchaseDetailEntity)
        {
            try
            {
                return _inventoryTransactionPurchaseDetail.CreateInventoryTransactionPurchaseDetail(inventoryTransactionPurchaseDetailEntity);
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
        public bool Put(int id, [FromBody] InventoryTransactionPurchaseDetailEntity inventoryTransactionPurchaseDetailEntity)
        {
            try
            {
                if (id > 0)
                {
                    return _inventoryTransactionPurchaseDetail.UpdateInventoryTransactionPurchaseDetail(id, inventoryTransactionPurchaseDetailEntity);
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
        [Route("Remove/PurchaseDetailId/{id}")]
        [Route("Clear/PurchaseDetailId/{id}")]
        [Route("Delete/PurchaseDetailId/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var isSuccess = _inventoryTransactionPurchaseDetail.DeleteInventoryTransactionPurchaseDetail(id);
                    if (isSuccess)
                    {
                        return true;
                    }
                    throw new ApiDataException(1002, "Purchase Detail does not exist!", HttpStatusCode.NotFound);
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
