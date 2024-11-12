using MultiShop.Cargo.BussinesLayer.Abstract;
using MultiShop.Cargo.DataAccsessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BussinesLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task TCreateAsync(T entity)
        {
            await _genericDal.CreateAsync(entity);
        }

        public async Task<T> TGetByIdAsync(int id)
        {
            return await _genericDal.GetByIdAsync(id);
        }

        public async Task<List<T>> TGetListAsync()
        {
            return await _genericDal.GetListAsync();
        }

        public async Task<List<T>> TGetListByFilter(Expression<Func<T, bool>> where)
        {
            return await _genericDal.GetListByFilter(where);
        }

        public async Task TRemoveAsync(int id)
        {
           await _genericDal.RemoveAsync(id);
        }

        public async Task TUpdateAsync(T entity)
        {
            await _genericDal.UpdateAsync(entity);
        }
    }
}
