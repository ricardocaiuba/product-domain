using Microsoft.Extensions.DependencyInjection;
using ProductBoundedContext.Data.Context;
using ProductBoundedContext.Data.Repositories;
using ProductBoundedContext.Domain.IRepositories;
using ProductBoundedContext.Domain.UseCases.Implementations;
using ProductBoundedContext.Domain.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductBoundedContext.Dependencies
{
    public class RegisterDependencies
    {
        public static void RegisterData(IServiceCollection services, string connectionString)
        {
            // Singleton
            // Instancia uma única vez a classe.
            services.AddSingleton<ProductSqlDataContext>(new ProductSqlDataContext(connectionString));

            //Scoped
            // Instancia a classe por demanda.
            services.AddScoped<IProductRepository, ProductRepository>();
            // a INjeção de dependência é sempre a interfae com a classe que esta sendo a mesma implementada
        }

        public static void RegisterDomain(IServiceCollection services)
        {
            services.AddScoped<ICreateProduct, CreateProduct>();
        }
    }
}
