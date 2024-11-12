using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BussinesLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Entites;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        private readonly IMapper _mapper;
        public CargoDetailsController(ICargoDetailService cargoDetailService, IMapper mapper)
        {
            _cargoDetailService = cargoDetailService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoDetailByIdAsync(int id)
        {
            var value = await _cargoDetailService.TGetByIdAsync(id);
            var mappedValue = _mapper.Map<ResultCargoDetailByIdDto>(value);
            return Ok(mappedValue);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCargoDetailAsync(int id)
        {
            await _cargoDetailService.TRemoveAsync(id);

            return Ok("Kayıt Silindi");
        }
        [HttpGet]
        public async Task<IActionResult> GetCargoDetailListAsync()
        {
            var values = await _cargoDetailService.TGetListAsync();
            var mappedValues = _mapper.Map<List<ResultCargoDetailDto>>(values);
            return Ok(mappedValues);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoDetailAsync(CreateCargoDetailDto createCargoDetailDto)
        {
            var mappedValue = _mapper.Map<CargoDetail>(createCargoDetailDto);
            await _cargoDetailService.TCreateAsync(mappedValue);
            return Ok("Kayıt Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetailAsync(UpdateCargoDetailDto updateCargoDetailDto)
        {
            var value = await _cargoDetailService.TGetByIdAsync(updateCargoDetailDto.CargoDetailId);
            value.SenderCustomer = updateCargoDetailDto.SenderCustomer;
            value.ReciverCustomer = updateCargoDetailDto.ReciverCustomer;
            value.Barcode = updateCargoDetailDto.Barcode;
            value.CargoCompanyId = updateCargoDetailDto.CargoCompanyId;

            await _cargoDetailService.TUpdateAsync(value);
            return Ok("Kayıt Güncellendi");
        }
    }
}
