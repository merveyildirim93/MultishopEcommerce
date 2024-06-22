using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopEcommerce.Cargo.Dto.Dtos.CargoOperationDtos
{
    public class CargoOperationUpdateDto
    {
        public int CargoOperationId { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
