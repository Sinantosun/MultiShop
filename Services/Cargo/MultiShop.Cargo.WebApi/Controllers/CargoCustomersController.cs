using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BussinesLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Entites;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _customerService;
        private readonly IMapper _mapper;
        public CargoCustomersController(ICargoCustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCustomerByIdAsync(int id)
        {
            var value = await _customerService.TGetByIdAsync(id);
            var mappedValue = _mapper.Map<ResultCargoCustomerByIdDto>(value);
            return Ok(mappedValue);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCargoCustomerAsync(int id)
        {
            await _customerService.TRemoveAsync(id);
           
            return Ok("Kayıt Silindi");
        }
        [HttpGet]
        public async Task<IActionResult> GetCargoCustomerListAsync()
        {
            var values = await _customerService.TGetListAsync();
            var mappedValues = _mapper.Map<List<ResultCargoCustomerDto>>(values);
            return Ok(mappedValues);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomerAsync(CreateCargoCustomerDto createCargoCustomerDto)
        {
            var mappedValue = _mapper.Map<CargoCustomer>(createCargoCustomerDto);
            await _customerService.TCreateAsync(mappedValue);
            return Ok("Kayıt Eklendi"); 
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomerAsync(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            var value = await _customerService.TGetByIdAsync(updateCargoCustomerDto.CargoCustomerId);
            value.Name = updateCargoCustomerDto.Name;
            value.Surname = updateCargoCustomerDto.Surname;
            value.Phone = updateCargoCustomerDto.Phone;
            value.Address = updateCargoCustomerDto.Address;
            value.Email = updateCargoCustomerDto.Email;
            value.City = updateCargoCustomerDto.City;
            value.District = updateCargoCustomerDto.District;
    
            await _customerService.TUpdateAsync(value);
            return Ok("Kayıt Güncellendi");
        }
    }
}
