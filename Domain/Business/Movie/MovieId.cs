using EventFlow.Core;

namespace Domain.Business.Movie
{
    public class MovieId : Identity<MovieId>
    {
        public MovieId(string val) : base(val)
        {
            
        }
    }
}