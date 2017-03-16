using System;
using System.Linq.Expressions;
using Movies.Data.Models;

namespace Movies.Web.Models
{
    public class MovieViewModel
    {
        public static Expression<Func<Movie, MovieViewModel>> FromMovie
        {
            get
            {
                return x => new MovieViewModel
                {
                    Id = x.Id,
                    Title = x.Title
                };
            }
        }

        public string Title { get; set; }

        public int Id { get; set; }

    }
}
