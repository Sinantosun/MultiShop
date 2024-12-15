using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class CouponService : ICouponService
    {
        private readonly DapperContext _context;

        public CouponService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@p1,@p2,@p3,@p4)";
            var parametres = new DynamicParameters();
            parametres.Add("@p1", createCouponDto.Code);
            parametres.Add("@p2", createCouponDto.Rate);
            parametres.Add("@p3", createCouponDto.IsActive);
            parametres.Add("@p4", createCouponDto.ValidDate);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parametres);
        }

        public async Task DeleteCouponAsync(int id)
        {
            var query = "delete from Coupons where CouponId = @p1";
            var parametres = new DynamicParameters();
            parametres.Add("@p1", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parametres);
        }

        public async Task<ResultCouponByIdDto> GetCouponByIdAsync(int id)
        {
            var query = "select * from Coupons where CouponId = @p1";
            var parametres = new DynamicParameters();
            parametres.Add("@p1", id);
            var connection = _context.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<ResultCouponByIdDto>(query, parametres);
            return value;

        }

        public async Task<GetDiscountCodeDetailByCode> GetCouponDetailByCouponAsync(string coupon)
        {
            var query = "select * from Coupons where Code=@p1";
            var parametres = new DynamicParameters();
            parametres.Add("@p1", coupon);
            var connection = _context.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<GetDiscountCodeDetailByCode>(query, parametres);
            return value;

        }

        public async Task<List<ResultCouponDto>> GetCouponListAsync()
        {
            var query = "select * from Coupons";
            var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<ResultCouponDto>(query);
            return result.ToList();

        }

        public async Task<int> GetCouponRateByCouponAsync(string coupon)
        {
            var query = "select Rate from Coupons where Code=@p1";
            var parametres = new DynamicParameters();
            parametres.Add("@p1", coupon);
            var connection = _context.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<int>(query, parametres);
            return value;
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "update Coupons set Code = @p1,Rate=@p2,IsActive=@p3,ValidDate=@p4 where CouponId = @p5 ";
            var parametres = new DynamicParameters();
            parametres.Add("@p1", updateCouponDto.Code);
            parametres.Add("@p2", updateCouponDto.Rate);
            parametres.Add("@p3", updateCouponDto.IsActive);
            parametres.Add("@p4", updateCouponDto.ValidDate);
            parametres.Add("@p5", updateCouponDto.CouponId);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parametres);
        }
    }
}
