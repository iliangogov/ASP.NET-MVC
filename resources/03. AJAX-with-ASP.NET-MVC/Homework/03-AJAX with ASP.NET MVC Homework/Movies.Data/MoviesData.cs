using System;
using System.Collections.Generic;
using System.Data.Entity;
using Movies.Data.Contracts;

namespace Movies.Data.Repositories
{
    public class SimpleTwitterData : IMoviesData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        public SimpleTwitterData()
        {
            //Homework, no time for setting up IOC Container
            this.context = new MoviesDbContext();
            this.repositories = new Dictionary<Type, object>();
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);

            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EfRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}