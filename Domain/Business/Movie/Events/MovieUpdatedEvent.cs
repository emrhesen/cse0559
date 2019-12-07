using EventFlow.Aggregates;
using EventFlow.EventStores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Business.Movie.Events
{
    [EventVersion("MovieUpdated", 1)]
    public class MovieUpdatedEvent : AggregateEvent<MovieAggregate, MovieId>
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public int Budget { get; set; }

        public MovieUpdatedEvent(string name, string director, int budget)
        {
            Name = name;
            Director = director;
            Budget = budget;
        }
    }
}
