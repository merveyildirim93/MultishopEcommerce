using MultishopEcommerce.Cargo.DataAccess.Abstract;
using MultishopEcommerce.Cargo.DataAccess.Concrete;
using MultishopEcommerce.Cargo.DataAccess.Repositories;
using MultishopEcommerce.Cargo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopEcommerce.Cargo.DataAccess.EntityFramework
{
    public class EfCargoCompanyDal:GenericRepository<CargoCompany>, ICargoCompanyDal
    {
        public EfCargoCompanyDal(CargoContext context) : base(context)
        {
                        
        }
    }
}
