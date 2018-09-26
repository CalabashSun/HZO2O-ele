using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using O2OApi.Core.Infrastructure;
using O2OApi.Core.Infrastructure.DependencyManagement;

namespace O2OApi.Web.Framework.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, IServiceCollection services)
        {
            //file provider
            builder.RegisterType<ProjectFileProvider>().As<IProjectFileProvider>().InstancePerLifetimeScope();
           

        }
        

        public int Order => 0;
    }
}
