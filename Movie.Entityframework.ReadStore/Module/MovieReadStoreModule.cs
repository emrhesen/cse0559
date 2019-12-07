using Domain.Application.CommandServices;
using Domain.Application.QueryServices;
using EventFlow;
using EventFlow.Configuration;
using EventFlow.EntityFramework;
using EventFlow.EntityFramework.Extensions;
using EventFlow.Extensions;
using Infrastructure.ReadStores;
using Movie.Entityframework.ReadStore.EntityframeworkContext;
using Movie.Entityframework.ReadStore.ReadModels;
using Movie.Entityframework.ReadStore.Services;

namespace Movie.Entityframework.ReadStore.Module
{
    public class MovieReadStoreModule : IModule
    {
        public void Register(IEventFlowOptions eventFlowOptions)
        {
            eventFlowOptions.ConfigureEntityFramework(EntityFrameworkConfiguration.New)
                .AddDefaults(typeof(MovieReadStoreModule).Assembly)
                .AddDbContextProvider<MovieContext, MovieContextProvider>()
                .UseEntityFrameworkEventStore<MovieContext>()
                .UseEntityFrameworkReadModel<MovieReadModel, MovieContext>()
                .RegisterServices(x =>
                {
                    x.Register<IMovieCommandService, MovieCommandService>();
                    x.Register<IMovieQueryService,MovieQueryService>();
                    x.Register<ISearchableReadModelStore<MovieReadModel>, EfSearchableReadStore<MovieReadModel,MovieContext>>();
                });
        }
    }
}