using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultishopEcommerce.Discount.Entities;
using System.Data;

namespace MultishopEcommerce.Discount.Context
{
    public class DapperContext: DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-KOTGCH6; initial Catalog=MultishopDiscountDb; integrated security=true; Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
