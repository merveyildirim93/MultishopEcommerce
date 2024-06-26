﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultishopEcommerce.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter);
        Task Update(T entity);
        Task Delete(T entity);
        Task Create(T entity);
    }
}
