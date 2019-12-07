using Microsoft.EntityFrameworkCore;
using Movie.Entityframework.ReadStore.ReadModels;

namespace Movie.Entityframework.ReadStore.EntityframeworkContext
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        
        public DbSet<MovieReadModel> Movies { get; set; }
    }
}