using System.Data.Entity;
using Movies.Data;
using Movies.Data.Migrations;

namespace Movies
{
    internal class DatabaseConfig
    {
        public static void Config()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesDbContext, Configuration>());
            MoviesDbContext.Create().Database.CreateIfNotExists();
        }
    }
}