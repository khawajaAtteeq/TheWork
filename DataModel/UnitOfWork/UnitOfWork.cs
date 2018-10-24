using DataModel.GenericRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace DataModel.UnitOfWork
{
    /// <summary>
    /// To give a heads up, again from my existing article, the important responsibilities of Unit of Work are,
    /// To manage transactions.
    /// To order the database inserts, deletes, and updates.
    /// To prevent duplicate updates. Inside a single usage of a Unit of Work object, 
    /// different parts of the code may mark the same Invoice object as changed, 
    /// but the Unit of Work class will only issue a single UPDATE command to the database.
    ///The value of using a Unit of Work pattern is to free the rest of our code 
    /// from these concerns so that you can otherwise concentrate on business logic.
    /// </summary>
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private member variables...
        private TheWorkEntities _context = null;
        private GenericRepository<UserInformation> _userRepository;
        private GenericRepository<Product> _productRepository;
        private GenericRepository<Token> _tokenRepository;
        private GenericRepository<InventoryItemGroup> _inventoryItemGroupRepository;
        private GenericRepository<InventoryItem> _inventoryItemRepository;
        private GenericRepository<InventoryItemCategory> _inventoryItemCategoryRepository;
        private GenericRepository<AccountsHeadAccount> _accountsHeadAccountRepository;
        private GenericRepository<AccountsGroupAccount> _accountsGroupAccountRepository;
        private GenericRepository<AccountsDetailAccount> _accountsDetailAccountRepository;
        private GenericRepository<AccountsBalanceSheetNote> _accountsBalanceSheetNoteRepository;
        private GenericRepository<AccountsProfitLoseNote> _accountsProfitLoseNoteRepository;
        private GenericRepository<AccountsVoucherType> _accountsVoucherTypeRepository;
        private GenericRepository<AccountsTransactionVoucherHead> _accountsTransactionVoucherHeadRepository;
        private GenericRepository<InventoryTransactionSaleDetail> _inventoryTransactionSaleDetailRepository;
        private GenericRepository<InventoryTransactionPurchaseHead> _inventoryTransactionPurchaseHeadRepository;
        private GenericRepository<InventoryTransactionPurchaseDetail> _inventoryTransactionPurchaseDetailRepository;
        //public UnitOfWork(TheWorkEntities context, GenericRepository<UserInformation> userRepository, GenericRepository<Product> productRepository, GenericRepository<Token> tokenRepository)
        //{
        //    _context = context;
        //    _userRepository = userRepository;
        //    _productRepository = productRepository;
        //    _tokenRepository = tokenRepository;
        //}

        public UnitOfWork()
        {
            _context = new TheWorkEntities();
        }

        #endregion
        #region Public Repository Creation properties...
        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new GenericRepository<Product>(_context);
                return _productRepository;
            }
        }
        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<UserInformation> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository<UserInformation>(_context);
                return _userRepository;
            }
        }
        /// <summary>
        /// Get/Set Property for token repository.
        /// </summary>
        public GenericRepository<Token> TokenRepository
        {
            get
            {
                if (_tokenRepository == null)
                    _tokenRepository = new GenericRepository<Token>(_context);
                return _tokenRepository;
            }
        }

        public GenericRepository<InventoryItemGroup> InventoryItemGroupRepository
        {
            get
            {
                if (_inventoryItemGroupRepository == null)
                    _inventoryItemGroupRepository = new GenericRepository<InventoryItemGroup>(_context);
                return _inventoryItemGroupRepository;
            }
        }

        public GenericRepository<InventoryItem> InventoryItemRepository {
            get
            {
                if (_inventoryItemRepository == null)
                    _inventoryItemRepository = new GenericRepository<InventoryItem>(_context);
                return _inventoryItemRepository;
            }
    }

        public GenericRepository<InventoryItemCategory> InventoryItemCategoryRepository
        {
            get
            {
                if (_inventoryItemCategoryRepository == null)
                    _inventoryItemCategoryRepository = new GenericRepository<InventoryItemCategory>(_context);
                return _inventoryItemCategoryRepository;
            }
        }

        public GenericRepository<AccountsHeadAccount> AccountsHeadAccountRepository
        {
            get
            {
                if (_accountsHeadAccountRepository == null)
                    _accountsHeadAccountRepository = new GenericRepository<AccountsHeadAccount>(_context);
                    return _accountsHeadAccountRepository;
            }
        }

        public GenericRepository<AccountsGroupAccount> AccountsGroupAccountRepository
        {
            get
            {
                if (_accountsGroupAccountRepository == null)
                    _accountsGroupAccountRepository = new GenericRepository<AccountsGroupAccount>(_context);
                return _accountsGroupAccountRepository;
            }
        }

        public GenericRepository<AccountsDetailAccount> AccountsDetailAccountRepository
        {
            get
            {
                if (_accountsDetailAccountRepository == null)
                    _accountsDetailAccountRepository = new GenericRepository<AccountsDetailAccount>(_context);
                return _accountsDetailAccountRepository;
            }
        }

        public GenericRepository<AccountsBalanceSheetNote> AccountsBalanceSheetNoteRepository
        {
            get
            {
                if (_accountsBalanceSheetNoteRepository == null)
                    _accountsBalanceSheetNoteRepository = new GenericRepository<AccountsBalanceSheetNote>(_context);
                return _accountsBalanceSheetNoteRepository;
            }
        }

        public GenericRepository<AccountsProfitLoseNote> AccountsProfitLoseNoteRepository
        {
            get
            {
                if (_accountsProfitLoseNoteRepository == null)
                    _accountsProfitLoseNoteRepository = new GenericRepository<AccountsProfitLoseNote>(_context);
                return _accountsProfitLoseNoteRepository;
            }
        }

        public GenericRepository<AccountsVoucherType> AccountsVoucherTypeRepository
        {
            get
            {
                if (_accountsVoucherTypeRepository == null)
                    _accountsVoucherTypeRepository = new GenericRepository<AccountsVoucherType>(_context);
                return _accountsVoucherTypeRepository;
            }
        }

        public GenericRepository<AccountsTransactionVoucherHead> AccountsTransactionVoucherHeadRepository
        {
            get
            {
                if (_accountsTransactionVoucherHeadRepository == null)
                    _accountsTransactionVoucherHeadRepository = new GenericRepository<AccountsTransactionVoucherHead>(_context);
                return _accountsTransactionVoucherHeadRepository;
            }
        }

        public GenericRepository<InventoryTransactionSaleDetail> InventoryTransactionSaleDetailRepository
        {
            get
            {
                if (_inventoryTransactionSaleDetailRepository == null)
                    _inventoryTransactionSaleDetailRepository = new GenericRepository<InventoryTransactionSaleDetail>(_context);
                return _inventoryTransactionSaleDetailRepository;
            }
        }

        public GenericRepository<InventoryTransactionPurchaseHead> InventoryTransactionPurchaseHeadRepository
        {
            get
            {
                if (_inventoryTransactionPurchaseHeadRepository == null)
                    _inventoryTransactionPurchaseHeadRepository = new GenericRepository<InventoryTransactionPurchaseHead>(_context);
                return _inventoryTransactionPurchaseHeadRepository;
            }
        }

        public GenericRepository<InventoryTransactionPurchaseDetail> InventoryTransactionPurchaseDetailRepository
        {
            get
            {
                if (_inventoryTransactionPurchaseDetailRepository == null)
                    _inventoryTransactionPurchaseDetailRepository = new GenericRepository<InventoryTransactionPurchaseDetail>(_context);
                return _inventoryTransactionPurchaseDetailRepository;
            }
        }

        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);
                throw e;
            }
        }
        #endregion

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        #region Implementing IDiosposable...

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        
    }
}
