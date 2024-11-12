using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccsessLayer.Abstract;
using MultiShop.Cargo.DataAccsessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccsessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _context;

        public GenericRepository(CargoContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var value = await _context.Set<T>().FindAsync(id);
            return value;
        }

        public async Task<List<T>> GetListAsync()
        {
            var values = await _context.Set<T>().ToListAsync();
            return values;
        }

        public async Task<List<T>> GetListByFilter(Expression<Func<T, bool>> where)
        {
            var values = await _context.Set<T>().Where(where).ToListAsync();
            return values;
        }

        public async Task RemoveAsync(int id)
        {
            var value = await GetByIdAsync(id);
            _context.Set<T>().Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();  
        }
    }
}
