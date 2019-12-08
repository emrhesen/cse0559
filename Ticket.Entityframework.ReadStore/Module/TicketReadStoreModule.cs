using Domain.Application.CommandServices;
using EventFlow;
using EventFlow.Configuration;
using EventFlow.EntityFramework;
using EventFlow.EntityFramework.Extensions;
using EventFlow.Extensions;
using Infrastructure.ReadStores;
using System;
using System.Collections.Generic;
using System.Text;
using Ticket.Entityframework.ReadStore.EntityframeworkContext;
using Ticket.Entityframework.ReadStore.ReadModels;
using Ticket.Entityframework.ReadStore.Services;

namespace Ticket.Entityframework.ReadStore.Module
{
    public class TicketReadStoreModule : IModule
    {
        public void Register(IEventFlowOptions eventFlowOptions)
        {
            eventFlowOptions.ConfigureEntityFramework(EntityFrameworkConfiguration.New)
                 .AddDefaults(typeof(TicketReadStoreModule).Assembly)
                 .AddDbContextProvider<TicketContext, TicketContextProvider>()
                 .UseEntityFrameworkEventStore<TicketContext>()
                 .UseEntityFrameworkReadModel<TicketReadModel, TicketContext>()
                 .RegisterServices(x =>
                 {
                     x.Register<ITicketCommandService, TicketCommandService>();
                     x.Register<ISearchableReadModelStore<TicketReadModel>, EfSearchableReadStore<TicketReadModel, TicketContext>>();
                 });
        }
    }
}
