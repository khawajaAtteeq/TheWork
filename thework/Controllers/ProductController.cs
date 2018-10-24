using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices;
using TheWork.ActionFilters;
using TheWork.ErrorHelper;
using TheWork.Filters;


namespace TheWork.Controllers
{
    /// <summary>
    /// Add logic to call Business Service methods, 
    /// just make an object of Business Service and call its respective methods,
    /// </summary>
    //[ApiAuthenticationFilter]
    [RoutePrefix("v1/products/product")]
    public class ProductController : ApiController
    {
        #region Call service

        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            //In this case when the constructor of the controller is called, 
            //It will be served with pre-instantiated service instance, 
            //    and does not need to create an instance of the service,
            //our unity container did the job of object creation.
            _productServices = productServices;
        }

        readonly IProductServices productServices = new ProductServices();

        public ProductController()
        {
            _productServices = productServices;
        }

        #endregion

        #region Get Method
        // GET api/product
#pragma warning disable 618
        [Queryable]
        //[ApiAuthenticationFilter(true)]
        [Route("AllProducts")]
        [Route("All")]
        
        public HttpResponseMessage Get()
        {
            try
            {
                var products = _productServices.GetAllProducts();
                var productEntities = products as List<ProductEntity> ?? products.ToList();
                if (productEntities.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, productEntities);
                }
               // return Request.CreateResponse(HttpStatusCode.NotFound, "Nothing Found!");
                throw new ApiDataException(1000,"No Products Found",HttpStatusCode.NotFound);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Get By Id
        // GET api/product/5
        [Route("productid/{id?}")]
        [Route("particularproduct/{id?}")]
        [Route("myproduct/{id:range(1, 3)}")]
        public HttpResponseMessage Get(int id)
        {
            if (id != null)
            {
                var product = _productServices.GetProductById(id);
                if (product != null)
                    return Request.CreateResponse(HttpStatusCode.OK, product);

                throw new ApiDataException(1001, "No product found for this id.", HttpStatusCode.NotFound);
            }
            throw new ApiException()
            {
                ErrorCode = (int) HttpStatusCode.BadRequest, ErrorDescription = "Bad Request..."
            };

            #region with TRY CATCH
            /*
             * 
             *    try
            {
                if (id != null)
                {
                    var product = _productServices.GetProductById(id);
                    if (product != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, product);
                    }
                }
                throw new ApiDataException(1001, "No product found.", HttpStatusCode.NotFound);
                // return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found!");
            }
            catch (Exception)
            {
                throw new ApiException() { ErrorCode = (int)HttpStatusCode.BadRequest, 
                    ErrorDescription = "Bad Request..." };
            }
             * */
            #endregion
        }


        #endregion

        #region Post 
        // POST api/product
        [Route("Create")]
        [Route("Add")]
        [HttpPost]
        public int Post([FromBody] ProductEntity productEntity)
        {
            try
            {
                return _productServices.CreateProduct(productEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Update or PUT
        // PUT api/product/5
        [Route("Update/productId/{id}")]
        [Route("Modify/productId/{id}")]
        [HttpPut]
        public bool Put(int id, [FromBody] ProductEntity productEntity)
        {
            try
            {
                if (id >0)
                {
                    return _productServices.UpdateProduct(id, productEntity);
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
        [Route("Remove/productId/{id}")]
        [Route("Clear/productId/{id}")]
        [Route("Delete/productId/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                if (id != null && id > 0)
                {
                    var isSuccess = _productServices.DeleteProduct(id);
                    if (isSuccess)
                    {
                        return true;
                    }
                    throw new ApiDataException(1002,"Product does not exist!",HttpStatusCode.NotFound);
                    //return _productServices.DeleteProduct(id);
                }
                return false;
            }
            catch (Exception)
            {
                throw new ApiException()
                {
                    ErrorCode = (int) HttpStatusCode.BadRequest,
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
    }
}
