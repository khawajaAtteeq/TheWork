using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.GenericRepository;
using DataModel.UnitOfWork;
using Helper.Test;
using Moq;
using NUnit.Framework;

namespace BusinessServices.Test
{
    public class ProductServicesTest
    {
        #region Variables

        private IProductServices _productService;
        private IUnitOfWork _unitOfWork;
        private List<Product> _products;
        private GenericRepository<Product> _productRepository;
        private TheWorkEntities _dbEntities;
        #endregion

        #region Test fixture setup

        /// <summary>
        /// Test fixture setup is written as a onetime setup for all the tests.
        ///  It is like a constructor in terms of classes. When we start executing
        ///  setup, this is the first method to be executed. In this method we’ll
        ///  populate the dummy products data and decorate this method with the
        ///  [TestFixtureSetUp] attribute at the top that tells compiler that the
        ///  particular method is a TestFixtureSetup. [TestFixtureSetUp] attribute
        ///  is the part of NUnit framework, so include it in the class as a namespace 
        /// i.e. using NUnit.Framework;. Following is the code for TestFixtureSetup.
        /// Initial setup for tests
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            _products = SetUpProducts();
        }

        #endregion

        #region Setup

        /// <summary>
        /// Re-initializes test.
        /// 
        /// TestFixtureSetUp is a onetime run process where as [SetUp] marked method is 
        /// executed after each test. Each test should be independent and should be tested
        ///  with a fresh set of input. Setup helps us to re-initialize data for each test.
        ///  Therefore all the required initialization for tests are written in this particular
        ///  method marked with [SetUp] attribute. I have written few methods and initialized the
        ///  private variables in this method. These lines of code execute after each test ends, so
        ///  that individual tests do not depend on any other written test and do not get hampered with
        ///  other tests pass or fail status. Code for Setup,
        /// </summary>
        [SetUp]
        public void ReInitializeTest()
        {
            //We make use of Mock framework in this method to mock the private variable instances.
            //Like for _dbEntities we write _dbEntities = new Mock<TheWorkEntities>().Object; .
            //This means that we are mocking WebDbEntities class and getting its proxy object.
            //Mock class is the class
            //from Moq framework, so include the respective namespace using Moq; in the class

            _products = SetUpProducts();
            _dbEntities = new Mock<TheWorkEntities>().Object;
            _productRepository = SetUpProductRepository();

            //Here you can see that We are trying to mock the UnitOfWork instance
            //and forcing it to perform all its transactions and operations on
            //_productRepository that we have mocked earlier. This means that all
            //the transactions will be limited to the mocked repository and actual
            //database or actual repository will not be touched. Same goes for service
            //as well; we are initializing product Services with this mocked _unitOfWork.
            //So when we use _productService in actual tests, it actually works on mocked
            //UnitOfWork and test data only.

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.SetupGet(s => s.ProductRepository).Returns(_productRepository);
            _unitOfWork = unitOfWork.Object;
            _productService = new ProductServices(_unitOfWork);

        }

        #endregion

        #region Private member methods

        /// <summary>
        /// Setup dummy repository
        ///  We have created a method SetUpProductRepository() to mock
        ///  Product Repository and assign it to _productrepository in ReInitializeTest() method.
        /// </summary>
        /// <returns></returns>
        private GenericRepository<Product> SetUpProductRepository()
        {
            // Initialise repository
            // This single Line 
            var mockRepo = new Mock<GenericRepository<Product>>(MockBehavior.Default, _dbEntities);

            //mocks the Generic Repository for Product and mockRepo.Setup() mocks
            //the repository methods by passing relevant delegates to the method.


            // Setup mocking behavior
            mockRepo.Setup(p => p.GetAll()).Returns(_products);

            mockRepo.Setup(p => p.GetById(It.IsAny<int>()))
                .Returns(new Func<int, Product>(
                             id => _products.Find(p => p.Id.Equals(id))));

            mockRepo.Setup(p => p.Insert((It.IsAny<Product>())))
                .Callback(new Action<Product>(newProduct =>
                {
                    dynamic maxProductId = _products.Last().Id;
                    dynamic nextProductId = maxProductId + 1;
                    newProduct.Id = nextProductId;
                    _products.Add(newProduct);
                }));

            mockRepo.Setup(p => p.Update(It.IsAny<Product>()))
                .Callback(new Action<Product>(prod =>
                {
                    var oldProduct = _products.Find(a => a.Id == prod.Id);
                    oldProduct = prod;
                }));

            mockRepo.Setup(p => p.Delete(It.IsAny<Product>()))
                .Callback(new Action<Product>(prod =>
                {
                    var productToRemove =
                        _products.Find(a => a.Id == prod.Id);

                    if (productToRemove != null)
                        _products.Remove(productToRemove);
                }));

            // Return mock implementation object
            return mockRepo.Object;
        }

        /// <summary>
        /// Setup dummy products data
        /// SetUpproducts() method fetches products from DataInitializer class and not from
        ///  database.It also and assigns a unique id to each product by iterating them. The
        ///  result data is assigned to _products list to be used in setting up mock 
        /// repository and in every individual test for comparison of actual vs resultant output.
        /// </summary>
        /// <returns></returns>
        private static List<Product> SetUpProducts()
        {
            var prodId = new int();
            var products = DataInitializer.GetAllProducts();
            foreach (Product prod in products)
                prod.Id = ++prodId;
            return products;

        }

        #endregion

        #region Unit Tests

        /// <summary>
        /// Service should return all the products
        /// To start writing a test method, you need to decorate that test
        ///  method with [Test] attribute of NUnit framework. This attribute
        ///  specifies that particular method is a Unit Test method.
        ///Following is the unit test method I have written for the above
        ///  mentioned business service method,
        /// </summary>
        [Test]
        public void GetAllProductsTest()
        {
            var products = _productService.GetAllProducts();
            if (products != null)
            {
                //We used instance of _productService and called the GetAllProducts()
                //method, that will ultimately execute on mocked UnitOfWork and
                //Repository to fetch test data from _products list. 
                //The products returned from the method are of type 
                //BusinessEntities.ProductEntity and we need to compare
                //the returned products with our existing _products list
                // i.e. the list of DataModel.Product i.e. a mocked database
                //entity, so we need to convert the returned BusinessEntities.
                //ProductEntity list to DataModel.Product list. We do this with the following line of code,
                var productList =
                    products.Select(
                        productEntity =>
                        new Product { Id = productEntity.Id, 
                            ProductName = productEntity.ProductName }).
                        ToList();
                var comparer = new ProductComparer();
                //To assert the result we use CollectionAssert.AreEqual of 
                //NUnit where we pass both the lists and comparer.
                CollectionAssert.AreEqual(
                    productList.OrderBy(product => product, comparer),
                    _products.OrderBy(product => product, comparer), comparer);
            }
        }

        /// <summary>
        /// Service should return null
        /// </summary>
        [Test]
        public void GetAllProductsTestForNull()
        {
            _products.Clear();
            var products = _productService.GetAllProducts();
            Assert.Null(products);
            SetUpProducts();
        }

        /// <summary>
        /// Service should return product if correct id is supplied
        /// </summary>
        [Test]
        public void GetProductByRightIdTest()
        {
            var mobileProduct = _productService.GetProductById(2);
            if (mobileProduct != null)
            {
                Mapper.CreateMap<ProductEntity, Product>();
                var productModel = Mapper.Map<ProductEntity, Product>(mobileProduct);
                AssertObjects.PropertyValuesAreEquals(productModel,
                                                      _products.Find(a => a.ProductName.Contains("Mobile")));
            }
        }

        /// <summary>
        /// Service should return null
        /// </summary>
        [Test]
        public void GetProductByWrongIdTest()
        {
            var product = _productService.GetProductById(0);
            Assert.Null(product);
        }

        /// <summary>
        /// Add new product test
        /// </summary>
        [Test]
        public void AddNewProductTest()
        {
            var newProduct = new ProductEntity()
            {
                ProductName = "Android Phone"
            };

            var maxProductIdBeforeAdd = _products.Max(a => a.Id);
            newProduct.Id = maxProductIdBeforeAdd + 1;
            _productService.CreateProduct(newProduct);
            var addedproduct = new Product() { ProductName = newProduct.ProductName,
                Id = newProduct.Id };
            AssertObjects.PropertyValuesAreEquals(addedproduct, _products.Last());
            Assert.That(maxProductIdBeforeAdd + 1, Is.EqualTo(_products.Last().Id));
        }

        /// <summary>
        /// Update product test
        /// </summary>
        [Test]
        public void UpdateProductTest()
        {
            var firstProduct = _products.First();
            firstProduct.ProductName = "Laptop updated";
            var updatedProduct = new ProductEntity() { ProductName = firstProduct.ProductName, Id = firstProduct.Id };
            _productService.UpdateProduct(firstProduct.Id, updatedProduct);
            Assert.That(firstProduct.Id, Is.EqualTo(1)); // hasn't changed
            Assert.That(firstProduct.ProductName, Is.EqualTo("Laptop updated")); // Product name changed
        }

        /// <summary>
        /// Delete product test
        /// </summary>
        [Test]
        public void DeleteProductTest()
        {
            int maxID = _products.Max(a => a.Id); // Before removal
            var lastProduct = _products.Last();

            // Remove last Product
            _productService.DeleteProduct(lastProduct.Id);
            Assert.That(maxID, Is.GreaterThan(_products.Max(a => a.Id))); // Max id reduced by 1
        }

        #endregion

        #region Tear Down

        /// <summary>
        /// Tears down each test data
        /// 
        /// Like test Setup runs after every test, similarly Test [TearDown] is invoked
        ///  after every test execution is complete. You can use tear down to dispose and
        ///  nullify the objects that are initialized while setup. The method for tear down
        ///  should be  decorated with [TearDown] attribute. Following is the test tear down
        ///  implementation.
        /// </summary>
        [TearDown]
        public void DisposeTest()
        {
            _productService = null;
            _unitOfWork = null;
            _productRepository = null;
            if (_dbEntities != null)
                _dbEntities.Dispose();
            _products = null;
        }

        #endregion

        #region TestFixture TearDown.

        /// <summary>
        /// TestFixture teardown
        /// 
        /// Unlike TestFixtureSetup, tear down is used to de-allocate or dispose the objects.
        ///  It also executes only one time when all the tests execution ends.
        ///  In our case we’ll use this method to nullify _products instance.
        ///  The attribute used for Test fixture tear down is [TestFixtureTearDown].
        /// </summary>
        [OneTimeTearDown]
        public void DisposeAllObjects()
        {
            _products = null;
        }

        #endregion
   
    }
}
