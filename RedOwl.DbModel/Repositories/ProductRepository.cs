using RedOwl.DbModel.Entities;
using RedOwl.DbModel.Repositories.Interfaces;

namespace RedOwl.DbModel.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(RedOwlDbContext context) : base(context)
        {
        }
    }
}
