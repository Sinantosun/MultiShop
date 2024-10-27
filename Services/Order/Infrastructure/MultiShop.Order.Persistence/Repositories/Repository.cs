using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderContext _orderContext;

        public Repository(OrderContext orderContext)
        {
            
            _orderContext = orderContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _orderContext.Set<T>().AddAsync(entity);
            await _orderContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _orderContext.Set<T>().FindAsync(id);
            _orderContext.Remove(value);
            await _orderContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var values = await _orderContext.Set<T>().ToListAsync();
            return values;
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            var value = await _orderContext.Set<T>().SingleOrDefaultAsync(filter);
            return value;
        }

        public async Task<List<T>> GetByFilterListAsync(Expression<Func<T, bool>> filter)
        {
            var values = await _orderContext.Set<T>().Where(filter).ToListAsync();
            return values;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var value = await _orderContext.Set<T>().FindAsync(id);
            return value;
        }

        public async Task UpdateAsync(T entity)
        {
            _orderContext.Update(entity);
            await _orderContext.SaveChangesAsync(); 
        }
    }
}
