using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedOwl.DbModel.Entities;
using RedOwl.DbModel.Repositories.Interfaces;

namespace RedOwl.DbModel.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private DbSet<T> entities;
        protected readonly RedOwlDbContext context;

        public DbSet<T> Entities => entities ?? (entities = context.Set<T>());

        protected Repository(RedOwlDbContext context)
        {
            this.context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(string.Format("Null entity can't be inserted {0}", typeof(T)));
                }

                Entities.Add(entity);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ICollection<T>> FindAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await Entities.Where(match).ToListAsync();
        }
    }
}
