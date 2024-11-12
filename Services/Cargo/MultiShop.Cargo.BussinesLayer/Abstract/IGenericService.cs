using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BussinesLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<List<T>> TGetListAsync();
        Task<T> TGetByIdAsync(int id);
        Task TUpdateAsync(T entity);
        Task TRemoveAsync(int id);
        Task TCreateAsync(T entity);
        Task<List<T>> TGetListByFilter(Expression<Func<T, bool>> where);
    }
}
