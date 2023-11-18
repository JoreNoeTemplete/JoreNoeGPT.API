using JoreNoeBackTemplete.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JoreNoeBackTemplete.Repository
{
    public class JoreNoeBackTempleteDBCntext : DbContext
    {
        public JoreNoeBackTempleteDBCntext()
        {
            //this.Configuration = configuration;
            //如果要访问的数据库存在，则不做操作，如果不存在，会自动创建所有数据表和模式
            //Database.EnsureCreated();

        }

        /// <summary>
        /// 配置
        /// </summary>
        public IConfiguration Configuration { set; get; }

        /// <summary>
        /// 订单表
        /// </summary>
        public DbSet<Test> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(this.Configuration.GetConnectionString("DbConnect")))
                optionsBuilder.UseSqlServer(this.Configuration.GetConnectionString("DbConnect"));
            else
                optionsBuilder.UseSqlServer("Server=182.61.5.163;Database=ZerroMovieDbContext;Uid=sa;Password=@JoreNoe123");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().HasQueryFilter(t => t.IsDelete == false);
        }
    }
}
