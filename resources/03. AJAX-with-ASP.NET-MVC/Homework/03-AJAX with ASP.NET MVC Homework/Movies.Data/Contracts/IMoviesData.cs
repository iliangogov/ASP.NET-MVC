namespace Movies.Data.Contracts
{
    using Repositories;

    public interface IMoviesData
    {
        //IRepository<Tweet> Tweets { get; }

        int SaveChanges();
    }
}