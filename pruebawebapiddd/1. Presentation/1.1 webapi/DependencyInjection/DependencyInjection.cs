using System;
using Application.Core;
using AutoMapper;
using Domain.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data.Core;
using Application.Contracts;
using Application.Implementation;
using Domain.Contracts;
using Data.Implementation;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace pruebawebapiddd
{
    public class DependencyInjection
    {
        public void RegisterServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton(configuration);

            services.AddMemoryCache();

            // AutoMapper
            services.AddAutoMapper(cfg => cfg.AddProfile<MapperProfile>(),
                    AppDomain.CurrentDomain.GetAssemblies());

            #region Application

            services.AddScoped<IDepartmentsService, DepartmentsService>();
            services.AddScoped<ICitiesService, CitiesService>();

            #endregion

            #region Domain

            services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
            services.AddScoped<ICitiesRepository, CitiesRepository>();


            #endregion

            #region Infrastructure

            services.AddScoped<IContextUnitOfWork, WorkUniversityContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddHttpClient();

            #endregion

            services.AddDbContext<WorkUniversityContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionDB")));


        }


    }
}