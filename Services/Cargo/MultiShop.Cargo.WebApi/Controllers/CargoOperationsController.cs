using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BussinesLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Entites;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;
        private readonly IMapper _mapper;
        public CargoOperationsController(ICargoOperationService cargoOperationService, IMapper mapper)
        {
            _cargoOperationService = cargoOperationService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoOperationByIdAsync(int id)
        {
            var value = await _cargoOperationService.TGetByIdAsync(id);
            var mappedValue = _mapper.Map<ResultCargoOperationByIdDto>(value);
            return Ok(mappedValue);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCargoOperationAsync(int id)
        {
            await _cargoOperationService.TRemoveAsync(id);

            return Ok("Kayıt Silindi");
        }
        [HttpGet]
        public async Task<IActionResult> GetCargoOperationListAsync()
        {
            var values = await _cargoOperationService.TGetListAsync();
            var mappedValues = _mapper.Map<List<ResultCargoOperationDto>>(values);
            return Ok(mappedValues);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoOperationAsync(CreateCargoOperationDto createCargoOperationDto)
        {
            var mappedValue = _mapper.Map<CargoOperation>(createCargoOperationDto);
            await _cargoOperationService.TCreateAsync(mappedValue);
            return Ok("Kayıt Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperationAsync(UpdateCargoOperationDto updateCargoOperationDto)
        {
            var value = await _cargoOperationService.TGetByIdAsync(updateCargoOperationDto.CargoOperationId);
            value.OperationDate = DateTime.Now;
            value.Description = updateCargoOperationDto.Description;
            value.Barcode = updateCargoOperationDto.Barcode;    
          

            await _cargoOperationService.TUpdateAsync(value);
            return Ok("Kayıt Güncellendi");
        }
    }
}
