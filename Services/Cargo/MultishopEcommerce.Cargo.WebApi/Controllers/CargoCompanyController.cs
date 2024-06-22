using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultishopEcommerce.Cargo.Business.Abstract;
using MultishopEcommerce.Cargo.Dto.Dtos.CargoCompanyDtos;
using MultishopEcommerce.Cargo.Entity.Concrete;

namespace MultishopEcommerce.Cargo.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            List<CargoCompany> cargoCompanies = new List<CargoCompany>();
            cargoCompanies= _cargoCompanyService.TGetAll();
            return Ok(cargoCompanies);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CargoCompanyCreateDto dto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName = dto.CargoCompanyName,
                IsActive = true,
            };
            _cargoCompanyService.TInsert(cargoCompany);
            return Ok("Kargo şirketi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo şirketi silindi");
        }

        [HttpGet("{id}")]
        public IActionResult CargoCompanyGetById(int id)
        {
            CargoCompany cargoCompany = new CargoCompany();
            cargoCompany = _cargoCompanyService.TGetById(id);
            return Ok(cargoCompany);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(CargoCompanyUpdateDto dto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyId = dto.CargoCompanyId,
                CargoCompanyName = dto.CargoCompanyName,
                IsActive = dto.IsActive
            };
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Kargo şirketi güncellendi");
        }

    }
}
