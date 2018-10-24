using DataModel;
using AutoMapper;
using System.Linq;
using BusinessEntities;
using System.Transactions;
using DataModel.UnitOfWork;
using System.Collections.Generic;


namespace BusinessServices
{
    public class ProductServices:IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductServices(IUnitOfWork unitOfWork)
        {
            //Here also we’ll get the pre instantiated object on UnitOfWork
            _unitOfWork = unitOfWork;
        }

        public ProductServices()
        {
        }

        //We have decided not to expose our db entities to Web API project, 
        //so we need something to map the db entities data to my business entity 
        //classes. We’ll make use of AutoMapper
        //http://www.codeproject.com/Articles/986460/What-is-Automapper
        //to centralize the mapping code and reuse this mapping code again and again.
        //This is where our super hero “AutoMapper” comes to the rescue. “Automapper”
        //sits in between both the objects like a bridge and maps the property data of both objects.

        //real time scenarios of the use of Automapper?
        //When you are moving data from ViewModel to Model in projects like MVC.
    
        /// <summary>
        /// Fetches product details by id
        /// 
        /// To get product by id ( GetproductById ) : 
        /// We call repository to get the product by id. 
        /// Id comes as a parameter from the calling method 
        /// to that service method. It returns the product 
        /// entity from the database.Note that it will not
        ///  return the exact db entity, instead we’ll map 
        /// it with our business entity using AutoMapper and
        ///  return it to calling method.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProductEntity GetProductById(int productId)
        {
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<Product, ProductEntity>();
            //});

            var product = _unitOfWork.ProductRepository.GetById(productId);
            if (product != null)
            {
              
                Mapper.CreateMap<Product, ProductEntity>();
                var productModel = Mapper.Map<Product, ProductEntity>(product);
                return productModel;
            }
            return null;
        }
        /// <summary>
        /// Fetches all the products.
        /// 
        /// Get all products from database (GetAllProducts) : 
        /// This method returns all the products residing in database,
        ///  again we make use of AutoMapper to map the list and return back.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductEntity> GetAllProducts()
        {
            var products = _unitOfWork.ProductRepository.GetAll().ToList();
            if (products.Any())
            {
                Mapper.CreateMap<Product, ProductEntity>();
                var productsModel = Mapper.Map<List<Product>, List<ProductEntity>>(products);
                return productsModel;
            }
            return null;
        }
        /// <summary>
        /// Create a new product (CreateProduct) : 
        /// This method takes product BusinessEntity as an 
        /// argument and creates a new object of actual database entity 
        /// and insert it using unit of work.
        /// </summary>
        /// <param name="productEntity"></param>
        /// <returns></returns>
        public int CreateProduct(ProductEntity productEntity)
        {
            using (var scope = new TransactionScope())
            {
                var product = new Product
                {
                    ProductName = productEntity.ProductName
                };
                _unitOfWork.ProductRepository.Insert(product);
                _unitOfWork.Save();
                scope.Complete();
                return product.Id;
            }
        }
        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productEntity"></param>
        /// <returns></returns>
        public bool UpdateProduct(int productId, ProductEntity productEntity)
        {
            var success = false;
            if (productEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var product = _unitOfWork.ProductRepository.GetById(productId);
                    if (product != null)
                    {
                        product.ProductName = productEntity.ProductName;
                        _unitOfWork.ProductRepository.Update(product);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
        /// <summary>
        /// Deletes a particular product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DeleteProduct(int productId)
        {
            var success = false;
            if (productId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var product = _unitOfWork.ProductRepository.GetById(productId);
                    if (product != null)
                    {
                        _unitOfWork.ProductRepository.Delete(product);
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
