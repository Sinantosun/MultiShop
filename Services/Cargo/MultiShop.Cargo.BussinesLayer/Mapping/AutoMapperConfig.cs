using AutoMapper;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BussinesLayer.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultCompanyDto, CargoCompany>().ReverseMap();
            CreateMap<CreateCompanyDto, CargoCompany>().ReverseMap();
            CreateMap<UpdateCompanyDto, CargoCompany>().ReverseMap();
            CreateMap<ResultCompanyByIdDto, CargoCompany>().ReverseMap();


            CreateMap<ResultCargoCustomerDto, CargoCustomer>().ReverseMap();
            CreateMap<CreateCargoCustomerDto, CargoCustomer>().ReverseMap();
            CreateMap<UpdateCargoCustomerDto, CargoCustomer>().ReverseMap();
            CreateMap<ResultCargoCustomerByIdDto, CargoCustomer>().ReverseMap();

            CreateMap<ResultCargoDetailByIdDto, CargoDetail>().ReverseMap();
            CreateMap<ResultCargoDetailDto, CargoDetail>().ReverseMap();
            CreateMap<CreateCargoDetailDto, CargoDetail>().ReverseMap();
            CreateMap<UpdateCargoDetailDto, CargoDetail>().ReverseMap();

            CreateMap<ResultCargoOperationByIdDto, CargoOperation>().ReverseMap();
            CreateMap<ResultCargoOperationDto, CargoOperation>().ReverseMap();
            CreateMap<CreateCargoOperationDto, CargoOperation>().ReverseMap();
            CreateMap<UpdateCargoOperationDto, CargoOperation>().ReverseMap();
        }
    }
}
