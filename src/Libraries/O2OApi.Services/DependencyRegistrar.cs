using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using O2OApi.Core.DbContext;
using O2OApi.Core.Infrastructure;
using O2OApi.Core.Infrastructure.DependencyManagement;
using O2OApi.Services.DataServices;
using O2OApi.Services.Repositorys;

namespace O2OApi.Services
{
    public class DependencyRegistrar:IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, IServiceCollection services)
        {
            //services
            builder.RegisterType<DapperDbContext>().As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            services.Add(new ServiceDescriptor(serviceType: typeof(IO2OConfigService), implementationType: typeof(O2OConfigService), lifetime: ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(serviceType: typeof(IProductCategoryService), implementationType: typeof(ProductCategoryService), lifetime: ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(serviceType: typeof(IEleProductInfoService), implementationType: typeof(EleProductInfoService), lifetime: ServiceLifetime.Transient));


            //订单相关
            //builder.RegisterType<EleOrderInfoService>().As<IEleOrderInfoService>().InstancePerLifetimeScope();
            services.Add(new ServiceDescriptor(serviceType: typeof(IEleOrderInfoService), implementationType: typeof(EleOrderInfoService), lifetime: ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(serviceType: typeof(IEleOrderProductService), implementationType: typeof(EleOrderProductService), lifetime: ServiceLifetime.Transient));
        }

        public int Order { get; } = 1;
    }
}
