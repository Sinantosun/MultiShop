using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccsessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task<List<T>> GetListAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task RemoveAsync(int id);
        Task CreateAsync(T entity);
        Task<List<T>> GetListByFilter(Expression<Func<T, bool>> where);

    }
}
