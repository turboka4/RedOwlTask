using Microsoft.EntityFrameworkCore;
using RedOwl.DbModel.Entities;

namespace RedOwl.DbModel
{
    public class RedOwlDbContext : DbContext
    {
        public RedOwlDbContext(DbContextOptions<RedOwlDbContext> options)
            : base(options)
        {
        }

        #region Migrations

        //public RedOwlDbContext()
        //{
        //}

        ////Only use for migrations: Would cause errors when trying to point to other instances by config
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=RedOwl;User Id=postgres;Password=postgres;");
        //}

        #endregion

        public DbSet<Product> Products { get; set; }
    }
}
