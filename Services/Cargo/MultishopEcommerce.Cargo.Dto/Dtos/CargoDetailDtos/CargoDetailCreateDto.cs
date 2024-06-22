using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopEcommerce.Cargo.Dto.Dtos.CargoDetailDtos
{
    public class CargoDetailCreateDto
    {
        public string SenderCustomer { get; set; }
        public string ReceiverCustomer { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
    }
}
