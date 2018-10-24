using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataModel.GenericRepository;
using DataModel.UnitOfWork;
using Helper.Test;
using Moq;
using NUnit.Framework;

namespace BusinessServices.Test
{

    public class UserServicesTest
    {
        #region Variables

        private IUserService _userServices;
        private IUnitOfWork _unitOfWork;
        private List<UserInformation> _users;
        private GenericRepository<UserInformation> _userRepository;
        private TheWorkEntities _dbEntities;
        const string CorrectUserName = "khawaja";
        const string CorrectPassword = "khawaja";
        const string WrongUserName = "khawaja1";
        const string WrongPassword = "khawaja1";
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
            _users = SetUpUsers();
        }

        #endregion

        #region Setup

        /// <summary>
        /// Re-initializes test.
        /// </summary>
        [SetUp]
        public void ReInitializeTest()
        {
            _dbEntities = new Mock<TheWorkEntities>().Object;
            _userRepository = SetUpUserRepository();
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.SetupGet(s => s.UserRepository).Returns(_userRepository);
            _unitOfWork = unitOfWork.Object;
            _userServices = new UserServices(_unitOfWork);
        }

        #endregion

        #region Private member methods

        /// <summary>
        /// Setup dummy repository
        /// </summary>
        /// <returns></returns>
        private GenericRepository<UserInformation> SetUpUserRepository()
        {
            // Initialise repository
            var mockRepo = new Mock<GenericRepository<UserInformation>>(MockBehavior.Default, _dbEntities);

            // Setup mocking behavior
            mockRepo.Setup(p => p.GetAll()).Returns(_users);

            //mockRepo.Setup(s => s.Get(It.IsAny<Func<User, bool>>()))
            //    .Returns(
            //        (Func<User, bool> expr) =>
            //        DataInitializer.GetAllUsers().Where(u => u.UserName == CorrectUserName).FirstOrDefault(
            //            u => u.Password == CorrectPassword));

            //mockRepo.Setup(s => s.Get(It.IsAny<Func<User, bool>>()))
            //   .Returns(
            //       (Func<User, bool> expr) =>
            //       DataInitializer.GetAllUsers().Where(u => u.UserName == WrongUserName).FirstOrDefault(
            //           u => u.Password == WrongPassword));

            mockRepo.Setup(p => p.GetById(It.IsAny<int>()))
                .Returns(new Func<int, UserInformation>(
                             id => _users.Find(p => p.Id.Equals(id))));

            mockRepo.Setup(p => p.Insert((It.IsAny<UserInformation>())))
                .Callback(new Action<UserInformation>(newToken =>
                {
                    dynamic maxTokenID = _users.Last().Id;
                    dynamic nextTokenID = maxTokenID + 1;
                    newToken.Id = nextTokenID;
                    _users.Add(newToken);
                }));

            mockRepo.Setup(p => p.Update(It.IsAny<UserInformation>()))
                .Callback(new Action<UserInformation>(token =>
                {
                    var oldUser = _users.Find(a => a.Id == token.Id);
                    oldUser = token;
                }));

            mockRepo.Setup(p => p.Delete(It.IsAny<UserInformation>()))
                .Callback(new Action<UserInformation>(prod =>
                {
                    var userToRemove =
                        _users.Find(a => a.Id == prod.Id);

                    if (userToRemove != null)
                        _users.Remove(userToRemove);
                }));
            //Create setup for other methods too. note non virtauls methods can not be set up

            // Return mock implementation object
            return mockRepo.Object;
        }

        /// <summary>
        /// Setup dummy tokens data
        /// </summary>
        /// <returns></returns>
        private static List<UserInformation> SetUpUsers()
        {
            var userId = new int();
            var users = DataInitializer.GetAllUsers();
            foreach (UserInformation user in users)
                user.Id = ++userId;
            return users;
        }

        #endregion

        #region Unit Tests

        ///// <summary>
        ///// Authenticate with correct credentials
        ///// </summary>
        //[Test]
        //public void AuthenticateTest()
        //{

        //    var returnId = _userServices.Authenticate(CorrectUserName, CorrectPassword);
        //    var firstOrDefault = _users.Where(u => u.UserName == CorrectUserName).FirstOrDefault(u => u.Password == CorrectPassword);
        //    if (firstOrDefault != null)
        //        Assert.That(returnId, Is.EqualTo(firstOrDefault.UserId));
        //}

        ///// <summary>
        ///// Authenticate with correct credentials
        ///// </summary>
        //[Test]
        //public void AuthenticateWrongCredentialsTest()
        //{

        //    var returnId = _userServices.Authenticate(WrongUserName, WrongPassword);
        //    var firstOrDefault = _users.Where(u => u.UserName == WrongUserName).FirstOrDefault(u => u.Password == WrongPassword);
        //    Assert.That(returnId, firstOrDefault != null ? Is.EqualTo(firstOrDefault.UserId) : Is.EqualTo(0));
        //}

        #endregion

        #region Tear Down

        /// <summary>
        /// Tears down each test data
        /// </summary>
        [TearDown]
        public void DisposeTest()
        {
            _userServices = null;
            _unitOfWork = null;
            _userRepository = null;
            if (_dbEntities != null)
                _dbEntities.Dispose();
        }

        #endregion

        #region TestFixture TearDown.

        /// <summary>
        /// TestFixture teardown
        /// </summary>
        [OneTimeTearDown]
        public void DisposeAllObjects()
        {
            _users = null;
        }

        #endregion
    }

}
