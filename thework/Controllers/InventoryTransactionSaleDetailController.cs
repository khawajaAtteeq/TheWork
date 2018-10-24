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
    public class InventoryTransactionSaleDetailController : ApiController
    {
        #region Call service
        private readonly IInventoryTransactionSaleDetail _inventoryTransactionSaleDetail;
        public InventoryTransactionSaleDetailController(IInventoryTransactionSaleDetail inventoryTransactionSaleDetail)
        {
            _inventoryTransactionSaleDetail = inventoryTransactionSaleDetail;
        }
        readonly IInventoryTransactionSaleDetail inventoryTransactionSaleDetail = new InventoryTransactionSaleDetailServices();
        public InventoryTransactionSaleDetailController()
        {
            _inventoryTransactionSaleDetail = inventoryTransactionSaleDetail; 
        }
        #endregion

        #region Get All

#pragma warning disable CS0618 // Type or member is obsolete
        [Queryable]
#pragma warning restore CS0618 // Type or member is obsolete
                              //[ApiAuthenticationFilter(true)]
        [Route("AllTransactionSaleDetail")]
        [Route("All")]

        public HttpResponseMessage Get()
        {
            try
            {
                var sale = _inventoryTransactionSaleDetail.GetAllInventoryTransactionSaleDetails();
                var saleEntities = sale as List<InventoryTransactionSaleDetailEntity> ?? sale.ToList();
                if (saleEntities.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, saleEntities);
                }
                // return Request.CreateResponse(HttpStatusCode.NotFound, "Nothing Found!");
                throw new ApiDataException(1000, "No Sale Detail Found", HttpStatusCode.NotFound);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Get By Id
        // GET api/product/5
        [Route("saleDetailid/{id?}")]
        [Route("particularSaleDetail/{id?}")]
        [Route("mysaleDetail/{id:range(1, 3)}")]
        public HttpResponseMessage Get(int id)
        {
            if (id>0)
            {
                var sale = _inventoryTransactionSaleDetail.GetInventoryTransactionSaleDetailById(id);
                if (sale != null)
                    return Request.CreateResponse(HttpStatusCode.OK, sale);

                throw new ApiDataException(1001, "No Sale Detail found for this id.", HttpStatusCode.NotFound);
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
        public int Post([FromBody] InventoryTransactionSaleDetailEntity inventoryTransactionSaleDetailEntity)
        {
            try
            {
                return _inventoryTransactionSaleDetail.CreateInventoryTransactionSaleDetail(inventoryTransactionSaleDetailEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Update or PUT
        // PUT api/product/5
        [Route("Update/saleDetailId/{id}")]
        [Route("Modify/saleDetailId/{id}")]
        [HttpPut]
        public bool Put(int id, [FromBody] InventoryTransactionSaleDetailEntity inventoryTransactionSaleDetailEntity)
        {
            try
            {
                if (id > 0)
                {
                    return _inventoryTransactionSaleDetail.UpdateInventoryTransactionSaleDetail(id, inventoryTransactionSaleDetailEntity);
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
        [Route("Remove/saleDetailId/{id}")]
        [Route("Clear/saleDetailId/{id}")]
        [Route("Delete/saleDetailId/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var isSuccess = _inventoryTransactionSaleDetail.DeleteInventoryTransactionSaleDetail(id);
                    if (isSuccess)
                    {
                        return true;
                    }
                    throw new ApiDataException(1002, "Sale Detail does not exist!", HttpStatusCode.NotFound);
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

        #region Call service

        #endregion

        #region Call service

        #endregion

        #region Call service

        #endregion

        #region Call service

        #endregion

    }
}
