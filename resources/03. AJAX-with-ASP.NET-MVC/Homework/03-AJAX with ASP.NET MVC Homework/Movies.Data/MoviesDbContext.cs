using System.Data.Entity;
using Movies.Data.Contracts;
using Movies.Data.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Movies.Data
{
    public class MoviesDbContext : DbContext, IMoviesDbContext
    {
        public MoviesDbContext()
            : base("DefaultConnection")
        {
        }

        public virtual IDbSet<Person> People { get; set; }

        public virtual IDbSet<Studio> Studios { get; set; }

        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<Address> Addresses { get; set; }

        public static MoviesDbContext Create()
        {
            return new MoviesDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}