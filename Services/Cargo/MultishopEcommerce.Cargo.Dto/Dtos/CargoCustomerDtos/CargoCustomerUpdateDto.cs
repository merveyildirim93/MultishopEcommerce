using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopEcommerce.Cargo.Dto.Dtos.CargoCustomerDtos
{
    public class CargoCustomerUpdateDto
    {
        public int CargoCustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Distrint { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
