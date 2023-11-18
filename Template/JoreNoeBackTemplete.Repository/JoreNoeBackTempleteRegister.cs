using JoreNoe;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace JoreNoeBackTemplete.Repository
{
    public class JoreNoeBackTempleteRegister : ICurrencyRegister, IDisposable
    {
        private DbContext _dbContext;

        public JoreNoeBackTempleteRegister(IConfiguration Configuration)
        {
            this._dbContext = new JoreNoeBackTempleteDBCntext { Configuration = Configuration };
        }

        public DbContext Dbcontext { get => this._dbContext; set { this._dbContext = value; } }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}
