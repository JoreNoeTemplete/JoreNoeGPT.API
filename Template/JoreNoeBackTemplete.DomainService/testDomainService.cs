using JoreNoe;
using JoreNoe.Cache.Redis;
using JoreNoe.DB.EntityFrameWork.Core.SqlServer;
using JoreNoeBackTemplete.Domain.Entity;
using JoreNoeBackTemplete.DomainService.Inteface;
using JoreNoeBackTemplete.OAL.Models;
using JoreNoeBackTemplete.OAL.Values;
using System;
using System.Collections.Generic;
namespace ZerroMovies.DomainService
{
    public class testDomainService :BaseRepository ,ItestDomainService
    {
        private readonly IRepository<Guid, Test> test;
        private readonly IRedisManager redisManager;
        public testDomainService(
            IRepository<Guid, Test> test,
            IRedisManager redisManager,
            IUnitOfWork Unit):base(Unit)
        {
            this.test = test;
            this.redisManager = redisManager;
        }

        public TestValue k()
        {
            var xss = this.test.Single(Guid.NewGuid());
            
            return null;
        }

    }
}
