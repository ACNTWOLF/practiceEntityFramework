using practiceEntityFramework.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

using AdventureWorksAPI.Data;

namespace practiceEntityFramework.Data
{
    public class ProductspRepository : IProductSpRepository
    {
        private readonly AdventureWorksContext _context;
        public ProductspRepository(AdventureWorksContext context)
        {
            _context = context;
        }
        public async Task PutProductByAsync(DataTable product)
        {
            var cnx = _context.Database.GetDbConnection();
            await using (cnx)
            {
                if (cnx.State != ConnectionState.Open)
                    await cnx.OpenAsync();

                using var command = cnx.CreateCommand();
                command.CommandText = "dbo.usp_oe_PutProduct_v1";
                command.CommandType = CommandType.StoredProcedure;
                var productParam = new SqlParameter("@ProductTable", SqlDbType.Structured)
                {
                    Value = product,
                    TypeName = "dbo.ProductTableType" // Usa el nombre exacto como está en SQL Server
                };
                command.Parameters.Add(productParam);
                await command.ExecuteNonQueryAsync();
            }
        }

    }
}
