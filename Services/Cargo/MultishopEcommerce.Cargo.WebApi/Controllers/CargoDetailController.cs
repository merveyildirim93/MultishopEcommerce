using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultishopEcommerce.Cargo.Business.Abstract;
using MultishopEcommerce.Cargo.Dto.Dtos.CargoDetailDtos;
using MultishopEcommerce.Cargo.Entity.Concrete;

namespace MultishopEcommerce.Cargo.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            List<CargoDetail> cargoCompanies = new List<CargoDetail>();
            cargoCompanies = _cargoDetailService.TGetAll();
            return Ok(cargoCompanies);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CargoDetailCreateDto dto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                CargoCompanyId = dto.CargoCompanyId,
                Barcode = dto.Barcode,
                ReceiverCustomer = dto.ReceiverCustomer,
                SenderCustomer = dto.SenderCustomer
            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo detayı eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo detayı silindi");
        }

        [HttpGet("{id}")]
        public IActionResult CargoDetailGetById(int id)
        {
            CargoDetail cargoDetail = new CargoDetail();
            cargoDetail = _cargoDetailService.TGetById(id);
            return Ok(cargoDetail);
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(CargoDetailUpdateDto dto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                CargoDetailId = dto.CargoDetailId,
                CargoCompanyId = dto.CargoCompanyId,
                Barcode = dto.Barcode,
                ReceiverCustomer = dto.ReceiverCustomer,
                SenderCustomer = dto.SenderCustomer
            };
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Kargo detayı güncellendi");
        }
    }
}
