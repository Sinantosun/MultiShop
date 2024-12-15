using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface ICouponService
    {
        Task<List<ResultCouponDto>> GetCouponListAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task<ResultCouponByIdDto> GetCouponByIdAsync(int id);
        Task DeleteCouponAsync(int id);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);

        Task<GetDiscountCodeDetailByCode> GetCouponDetailByCouponAsync(string coupon);
        Task<int> GetCouponRateByCouponAsync(string coupon);



    } 
}
