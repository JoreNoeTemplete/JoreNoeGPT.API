using Exceptionless;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JoreNoeBackTemplete.API
{
    public partial class Startup
    {
        protected void AddExceptionless(IServiceCollection Service, IConfiguration Config)
        {
            var ExceptionlessKey = Config.GetSection("ExceptionlessKey").Value;
            Service.AddExceptionless(ExceptionlessKey);
        }
    }
}
