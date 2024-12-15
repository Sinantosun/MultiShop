﻿using MultiShop.DtoLayer.Dtos.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetDiscountCodeDetailByCode> GetDiscountCodeAsync(string code);
        Task<int> GetDiscountRateAsync(string code);
    }
}
