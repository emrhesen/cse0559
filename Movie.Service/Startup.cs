using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Module;
using EventFlow;
using EventFlow.AspNetCore.Extensions;
using EventFlow.DependencyInjection.Extensions;
using EventFlow.EntityFramework;
using EventFlow.Extensions;
using EventFlow.RabbitMQ;
using EventFlow.RabbitMQ.Extensions;
using EventStore.Middleware.Module;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Movie.Entityframework.ReadStore.EntityframeworkContext;
using Movie.Entityframework.ReadStore.Module;
using Swashbuckle.AspNetCore.Swagger;

namespace Movie.Service
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var env = EnvironmentConfiguration.Bind(_configuration);

            services.AddAutoMapper()
                .AddSingleton(env)
                .AddSwaggerGen(c => c.SwaggerDoc("v1", new Info {Title = "Movies API", Version = "v1"}))
                .AddMvcCore()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

//            services.AddControllers();

            return EventFlowOptions.New
                .UseServiceCollection(services)
                .AddAspNetCore()
                .UseConsoleLog()
                .RegisterModule<DomainModule>()
                .RegisterModule<MovieReadStoreModule>()
                .RegisterModule<EventSourcingModule>()
                .PublishToRabbitMq(RabbitMqConfiguration.With(new Uri(env.RabbitMqConnection)))
                .CreateServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<IDbContextProvider<MovieContext>>();
                dbContext.CreateContext();
            }
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API V1"); });
                app.UseMvc();
            }
            else
            {
                
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}