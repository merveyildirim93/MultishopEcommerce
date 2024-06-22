using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopEcommerce.Cargo.Dto.Dtos.CargoCompanyDtos
{
    public class CargoCompanyUpdateDto
    {
        public int CargoCompanyId { get; set; }
        public string CargoCompanyName { get; set; }
        public bool IsActive { get; set; }
    }
}
