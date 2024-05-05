using Microsoft.EntityFrameworkCore;
using MultishopEcommerce.Order.Domain.Entities;

namespace MultishopEcommerce.Order.Persistence.Context
{
    public class OrderContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1440; initial Catalog=MultishopOrderDb; User=sa; Password=123456*Aa; integrated security=true; TrustServerCertificate=True; Trusted_Connection=False; MultipleActiveResultSets=true");
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }

    }
}
