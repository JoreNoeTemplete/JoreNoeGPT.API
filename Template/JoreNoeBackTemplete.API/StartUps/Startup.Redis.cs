
namespace JoreNoeBackTemplete.API
{
    using JoreNoe.Cache.Redis;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public partial class Startup
    {
        protected void AddRedis(IServiceCollection Service, IConfiguration Config)
        {
            var RedisConnection = Config.GetSection("RedisConnection").Value;
            Register.InitRedisConfig(RedisConnection, "defualt");
            Register.AddJoreNoeRedis(Service);
        }

    }
}
