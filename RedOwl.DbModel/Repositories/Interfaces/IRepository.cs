using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RedOwl.DbModel.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task<ICollection<T>> FindAllAsync();
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
    }
}
