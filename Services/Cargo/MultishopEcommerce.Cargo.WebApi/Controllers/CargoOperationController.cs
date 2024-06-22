using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultishopEcommerce.Cargo.Business.Abstract;
using MultishopEcommerce.Cargo.Dto.Dtos.CargoOperationDtos;
using MultishopEcommerce.Cargo.Entity.Concrete;

namespace MultishopEcommerce.Cargo.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            List<CargoOperation> cargoCompanies = new List<CargoOperation>();
            cargoCompanies = _cargoOperationService.TGetAll();
            return Ok(cargoCompanies);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CargoOperationCreateDto dto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate
            };
            _cargoOperationService.TInsert(cargoOperation);
            return Ok("Kargo işlemi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo işlemi silindi");
        }

        [HttpGet("{id}")]
        public IActionResult CargoOperationGetById(int id)
        {
            CargoOperation cargoOperation = new CargoOperation();
            cargoOperation = _cargoOperationService.TGetById(id);
            return Ok(cargoOperation);
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(CargoOperationUpdateDto dto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                CargoOperationId = dto.CargoOperationId,
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate
            };
            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Kargo işlemi güncellendi");
        }
    }
}
