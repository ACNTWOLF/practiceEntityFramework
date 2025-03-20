using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksAPI.Models
{
    [Table("Product", Schema = "Production")]
    public class Product
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string? Color { get; set; }
        public short SafetyStockLevel { get; set; } // smallint => short
        public short ReorderPoint { get; set; }     // smallint => short
        public decimal StandardCost { get; set; }   // money => decimal
        public decimal ListPrice { get; set; }      // money => decimal
        public string? Size { get; set; }
        public string? SizeUnitMeasureCode { get; set; } // nchar => string
        public string? WeightUnitMeasureCode { get; set; } // nchar => string
        public decimal? Weight { get; set; }        // decimal => decimal (puede ser nullable)
        public int DaysToManufacture { get; set; }
        public string? ProductLine { get; set; }    // nchar => string
        public string? Class { get; set; }          // nchar => string
        public string? Style { get; set; }          // nchar => string
        public int? ProductSubcategoryID { get; set; } // int nullable
        public int? ProductModelID { get; set; }       // int nullable
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }     // datetime puede ser null
        public DateTime? DiscontinuedDate { get; set; } // datetime puede ser null
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

}
