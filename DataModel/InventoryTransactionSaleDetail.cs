//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class InventoryTransactionSaleDetail
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int ItemId { get; set; }
        public int ItemUnitId { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Nullable<double> VatPercentage { get; set; }
        public Nullable<decimal> Vat { get; set; }
        public Nullable<double> DiscountPercentage { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public decimal SaleAmount { get; set; }
        public string Comments { get; set; }
    }
}