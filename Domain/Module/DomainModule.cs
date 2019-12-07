using EventFlow;
using EventFlow.Configuration;
using EventFlow.Extensions;

namespace Domain.Module
{
    public class DomainModule : IModule
    {
        public void Register(IEventFlowOptions eventFlowOptions)
        {
            eventFlowOptions.AddDefaults(typeof(DomainModule).Assembly);
        }
    }
}