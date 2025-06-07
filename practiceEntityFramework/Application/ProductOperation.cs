using practiceEntityFramework.Interface;
using practiceEntityFramework.Entities.Products;
using System.Data;

namespace practiceEntityFramework.Application
{
    public class ProductOperation : IProductOperation
    {
        private readonly IProductSpRepository _repository;
        public ProductOperation(IProductSpRepository repository)
        {
            _repository = repository;
        }
        public async Task PutProduct(List<Product> products)
        {
            var dtProduct = await TransformDTProduct(products);
            await _repository.PutProductByAsync(dtProduct);
        }
        private Task<DataTable> TransformDTProduct(List<Product> products)
        {
            var table = new DataTable();

            table.Columns.Add("ProductID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("ProductNumber", typeof(string));
            table.Columns.Add("MakeFlag", typeof(int));
            table.Columns.Add("FinishedGoodsFlag", typeof(int));
            table.Columns.Add("Color", typeof(string));
            table.Columns.Add("SafetyStockLevel", typeof(short));
            table.Columns.Add("ReorderPoint", typeof(short));
            table.Columns.Add("StandardCost", typeof(decimal));
            table.Columns.Add("ListPrice", typeof(decimal));
            table.Columns.Add("Size", typeof(string));
            table.Columns.Add("SizeUnitMeasureCode", typeof(string));
            table.Columns.Add("WeightUnitMeasureCode", typeof(string));
            table.Columns.Add("Weight", typeof(decimal));
            table.Columns.Add("DaysToManufacture", typeof(int));
            table.Columns.Add("ProductLine", typeof(string));
            table.Columns.Add("Class", typeof(string));
            table.Columns.Add("Style", typeof(string));
            table.Columns.Add("ProductSubcategoryID", typeof(int));
            table.Columns.Add("ProductModelID", typeof(int));
            table.Columns.Add("SellStartDate", typeof(DateTime));
            table.Columns.Add("SellEndDate", typeof(DateTime));
            table.Columns.Add("DiscontinuedDate", typeof(DateTime));
            table.Columns.Add("Rowguid", typeof(Guid));
            table.Columns.Add("ModifiedDate", typeof(DateTime));

            foreach (var product in products)
            {
                table.Rows.Add(
                    product.ProductID,
                    product.Name,
                    product.ProductNumber,
                    product.MakeFlag,
                    product.FinishedGoodsFlag,
                    (object?)product.Color ?? DBNull.Value,
                    product.SafetyStockLevel,
                    product.ReorderPoint,
                    product.StandardCost,
                    product.ListPrice,
                    (object?)product.Size ?? DBNull.Value,
                    (object?)product.SizeUnitMeasureCode ?? DBNull.Value,
                    (object?)product.WeightUnitMeasureCode ?? DBNull.Value,
                    (object?)product.Weight ?? DBNull.Value,
                    product.DaysToManufacture,
                    (object?)product.ProductLine ?? DBNull.Value,
                    (object?)product.Class ?? DBNull.Value,
                    (object?)product.Style ?? DBNull.Value,
                    (object?)product.ProductSubcategoryID ?? DBNull.Value,
                    (object?)product.ProductModelID ?? DBNull.Value,
                    product.SellStartDate,
                    (object?)product.SellEndDate ?? DBNull.Value,
                    (object?)product.DiscontinuedDate ?? DBNull.Value,
                    product.Rowguid,
                    product.ModifiedDate
                );
            }

            return Task.FromResult(table);
        }
    }
}
