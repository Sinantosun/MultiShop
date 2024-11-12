using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BussinesLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Entites;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _companyService;
        private readonly IMapper _mapper;
        public CargoCompaniesController(ICargoCompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCargoCompaniesListAsync()
        {
            var values = await _companyService.TGetListAsync();
            var mappedValues = _mapper.Map<List<ResultCompanyDto>>(values);
            return Ok(mappedValues);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCompanyByIdAsync(int id)
        {
            var value = await _companyService.TGetByIdAsync(id);
            var mappedValue = _mapper.Map<List<ResultCompanyByIdDto>>(value);
            return Ok(mappedValue);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCompanyAsync(CreateCompanyDto createCompanyDto)
        {
            var mappedValue = _mapper.Map<CargoCompany>(createCompanyDto);
            await _companyService.TCreateAsync(mappedValue);
            return Ok("Kayıt Eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompanyAsync(UpdateCompanyDto updateCompanyDto)
        {
            var value = await _companyService.TGetByIdAsync(updateCompanyDto.CargoCompanyId);
            value.CamanpyName = updateCompanyDto.CamanpyName;
            await _companyService.TUpdateAsync(value);
            return Ok("Kayıt Güncelllendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCargoCompanyAsync(int id)
        {
            await _companyService.TRemoveAsync(id);
            return Ok("Kayıt Silindi.");
        }

    }
}
