﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TheWorkEntities : DbContext
    {
        public TheWorkEntities()
            : base("name=TheWorkEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccountsBalanceSheetNote> AccountsBalanceSheetNotes { get; set; }
        public virtual DbSet<AccountsDetailAccount> AccountsDetailAccounts { get; set; }
        public virtual DbSet<AccountsGroupAccount> AccountsGroupAccounts { get; set; }
        public virtual DbSet<AccountsHeadAccount> AccountsHeadAccounts { get; set; }
        public virtual DbSet<AccountsMainAccount> AccountsMainAccounts { get; set; }
        public virtual DbSet<AccountsProfitLoseNote> AccountsProfitLoseNotes { get; set; }
        public virtual DbSet<AccountsTransactionVoucherDetail> AccountsTransactionVoucherDetails { get; set; }
        public virtual DbSet<AccountsTransactionVoucherHead> AccountsTransactionVoucherHeads { get; set; }
        public virtual DbSet<AccountsVoucherType> AccountsVoucherTypes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<InventoryItemCategory> InventoryItemCategories { get; set; }
        public virtual DbSet<InventoryItemGroup> InventoryItemGroups { get; set; }
        public virtual DbSet<InventoryItem> InventoryItems { get; set; }
        public virtual DbSet<InventoryItemUnit> InventoryItemUnits { get; set; }
        public virtual DbSet<InventoryTransactionPurchaseDetail> InventoryTransactionPurchaseDetails { get; set; }
        public virtual DbSet<InventoryTransactionPurchaseHead> InventoryTransactionPurchaseHeads { get; set; }
        public virtual DbSet<InventoryTransactionSaleDetail> InventoryTransactionSaleDetails { get; set; }
        public virtual DbSet<InventoryTransactionSaleHead> InventoryTransactionSaleHeads { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<UserInformation> UserInformations { get; set; }
    }
}