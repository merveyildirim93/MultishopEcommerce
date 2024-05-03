using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultishopEcommerce.Order.Application.Interfaces;

namespace MultishopEcommerce.Order.Persistence.Repositories
{
    public class Repository<T>: IRepository<T> where T : class
    {
        private readonly OrderContext _orderContext;
        public Repository(OrderContext orderContext)
        {
                _orderContext = orderContext;
        }

        public async Task Create(T entity)
        {
            _orderContext.Set<T>().Add(entity);
            await _orderContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _orderContext.Set<T>().Remove(entity);
            await _orderContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _orderContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _orderContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetById(Expression<Func<T, bool>> filter)
        {
            return await _orderContext.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task Update(T entity)
        {
            _orderContext.Set<T>().Update(entity);
            await _orderContext.SaveChangesAsync();
        }

    }
}
