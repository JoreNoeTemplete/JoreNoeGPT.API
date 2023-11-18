﻿using AutoMapper;
using JoreNoe.Extend;
using JoreNoeBackTemplete.Domain.Entity;
using JoreNoeBackTemplete.OAL.Models;
using JoreNoeBackTemplete.OAL.Values;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace JoreNoeBackTemplete.API
{
    public partial class Startup
    {
        protected void AddAutoMapper(IServiceCollection services)
        {
            services.TryAddSingleton<MapperConfigurationExpression>();
            services.TryAddSingleton(serviceProvider =>
            {
                var mapperConfigurationExpression = serviceProvider.GetRequiredService<MapperConfigurationExpression>();
                var instance = new MapperConfiguration(mapperConfigurationExpression);

                instance.AssertConfigurationIsValid();
                return instance;
            });
            services.TryAddSingleton(serviceProvider =>
            {
                var mapperConfiguration = serviceProvider.GetRequiredService<MapperConfiguration>();

                return mapperConfiguration.CreateMapper();
            });
        }
        public void UseAutoMapper(IApplicationBuilder applicationBuilder)
        {
            var config = applicationBuilder.ApplicationServices.GetRequiredService<MapperConfigurationExpression>();

            config.CreateMap<Test, TestValue>(MemberList.None);
            config.CreateMap<TestModel, Test>(MemberList.None);



            //config.CreateMap<MovieComment, MovieCommentValue>(MemberList.None);
            //config.CreateMap<User, UserInfo>().ForMember(d => d.names, option => option.MapFrom(d => d.name)).ReverseMap();
        }
    }
}
