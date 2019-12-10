using Domain.Business.TicketOrder;
using Domain.Business.TicketOrder.Events;
using Domain.Module;
using EventFlow;
using EventFlow.Aggregates;
using EventFlow.AspNetCore.Extensions;
using EventFlow.Configuration;
using EventFlow.DependencyInjection.Extensions;
using EventFlow.Extensions;
using EventFlow.RabbitMQ;
using EventFlow.RabbitMQ.Extensions;
using EventFlow.Subscribers;
using Infrastructure.Configurations;
using Infrastructure.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EventConsumer
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
             .ConfigureAppConfiguration((host, config) =>
             {
                 config.SetBasePath(Directory.GetCurrentDirectory());
                 config.AddJsonFile("appsettings.json", true, true);
                 config.AddEnvironmentVariables();
             })
             .ConfigureServices(
              (hostcontext, services) =>
              {
                  var envconfig = EnvironmentConfiguration.Bind(hostcontext.Configuration);
                  services.AddSingleton(envconfig);

                  EventFlowOptions.New
          .Configure(cfg => cfg.IsAsynchronousSubscribersEnabled = true)
          .UseServiceCollection(services)
          .AddAspNetCore()
          .PublishToRabbitMq(RabbitMqConfiguration.With(new Uri($"{envconfig.RabbitMqConnection}"),
           true, 5, envconfig.RabbitExchange))
          .RegisterModule<DomainModule>()

          //
          // subscribe services changed
          //
          .AddAsynchronousSubscriber<TicketAggregate, TicketId, TicketRegisteredEvent, RabbitMqConsumePersistanceService>()
          .RegisterServices(s =>
          {
              s.Register<IHostedService, RabbitConsumePersistenceService>(Lifetime.Singleton);
              s.Register<IHostedService, RabbitMqConsumePersistanceService>(Lifetime.Singleton);
          });
              })
             .ConfigureLogging((hostingContext, logging) => { });

            await builder.RunConsoleAsync();
        }
    }

    public interface IRabbitMqConsumerPersistanceService
    {

    }

    public class RabbitMqConsumePersistanceService : IHostedService, IRabbitMqConsumerPersistanceService, ISubscribeAsynchronousTo<TicketAggregate, TicketId, TicketRegisteredEvent>
    {

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task HandleAsync(IDomainEvent<TicketAggregate, TicketId, TicketRegisteredEvent> domainEvent, CancellationToken cancellationToken)
        {

            Console.WriteLine($"Ticket Sold for {domainEvent.AggregateIdentity} with MovieId => {domainEvent.AggregateEvent.Ticket.MovieId}");


            return Task.CompletedTask;
        }

    }
}