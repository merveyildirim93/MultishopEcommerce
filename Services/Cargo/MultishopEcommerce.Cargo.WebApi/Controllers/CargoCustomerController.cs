using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultishopEcommerce.Cargo.Business.Abstract;
using MultishopEcommerce.Cargo.Dto.Dtos.CargoCustomerDtos;
using MultishopEcommerce.Cargo.Entity.Concrete;

namespace MultishopEcommerce.Cargo.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            List<CargoCustomer> cargoCompanies = new List<CargoCustomer>();
            cargoCompanies = _cargoCustomerService.TGetAll();
            return Ok(cargoCompanies);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CargoCustomerCreateDto dto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address = dto.Address,
                City = dto.City,
                Distrint = dto.Distrint,
                Mail = dto.Mail,
                Name = dto.Name,
                Phone = dto.Phone,
                Surname = dto.Surname
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Kargo müşterisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo müşterisi silindi");
        }

        [HttpGet("{id}")]
        public IActionResult CargoCustomerGetById(int id)
        {
            CargoCustomer cargoCustomer = new CargoCustomer();
            cargoCustomer = _cargoCustomerService.TGetById(id);
            return Ok(cargoCustomer);
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(CargoCustomerUpdateDto dto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerId = dto.CargoCustomerId,
                Address = dto.Address,
                City = dto.City,
                Distrint = dto.Distrint,
                Mail = dto.Mail,
                Name = dto.Name,
                Phone = dto.Phone,
                Surname = dto.Surname
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo müşterisi güncellendi");
        }

    }
}
