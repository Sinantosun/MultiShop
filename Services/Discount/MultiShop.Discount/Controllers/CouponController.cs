using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _service;

        public CouponController(ICouponService service)
        {
            _service = service;
        }
        [HttpGet("GetDiscountCoupon")]
        public async Task<IActionResult> GetDiscountCoupon()
        {
            var values = await _service.GetDiscountCouponCountAsync();
            return Ok(values);
        }
        [HttpGet("GetCouponRateByCoupon/{coupon}")]
        public async Task<IActionResult> GetCouponRateByCoupon(string coupon)
        {
            var values = await _service.GetCouponRateByCouponAsync(coupon);
            return Ok(values);
        }
        [HttpGet("GetCodeDetailByCode/{coupon}")]
        public async Task<IActionResult> GetCodeDetailByCode(string coupon)
        {
            var values = await _service.GetCouponDetailByCouponAsync(coupon);
            return Ok(values);
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _service.GetCouponListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _service.GetCouponByIdAsync(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteCouponAsync(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateCouponDto createCouponDto)
        {
            await _service.CreateCouponAsync(createCouponDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCouponDto updateCouponDto)
        {
            await _service.UpdateCouponAsync(updateCouponDto);
            return Ok();
        }
    }
}
