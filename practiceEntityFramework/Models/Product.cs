using System.ComponentModel.DataAnnotations;

namespace AdventureWorksAPI.Models
{
    public class Product
    {
        [Key] public int ProductID { get; set; }
     
        public string? Name { get; set; }
        public string? ProductNumber { get; set; }
        public int MekeFlag { get; set; }
        public int FinishedGoodsFlag { get; set; }
        public string? Color { get; set; }
        public int SafetyStockLevel { get; set; }
        public int ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string? Size { get; set; }
        public string? SizeUnitMeasureCode { get; set; }
        public string? WeightUnitMeasureCode { get; set; }
        public decimal Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string? ProductLine { get; set; }
        public string? Class { get; set; }
        public string? Style { get; set; }
        public string? ProductSubcategoryID { get; set; }
        public string? ProductModelID { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public string? rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
