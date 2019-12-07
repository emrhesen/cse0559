using EventFlow.Entities;

namespace Domain.Business.Movie
{
    public class MovieEntity : Entity<MovieId>
    {
        public MovieEntity(MovieId id) : base(id)
        {
        }

        public string Name { get; set; }
        public string Director { get; set; }
        public int Budget { get; set; }
    }
}