using Microsoft.EntityFrameworkCore;
using MultishopEcommerce.Cargo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopEcommerce.Cargo.DataAccess.Concrete
{
    public class CargoContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1441; initial Catalog=MultishopCargoDb; User=sa; Password=123456*Aa; integrated security=true; TrustServerCertificate=True; Trusted_Connection=False; MultipleActiveResultSets=true");
        }
        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoCustomer> CargoCustomers { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }
    }
}
