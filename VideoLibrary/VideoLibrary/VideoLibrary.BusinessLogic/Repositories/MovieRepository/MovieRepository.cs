﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;
using PagedList;

namespace VideoLibrary.BusinessLogic.Repositories.MovieRepository
{
    public class MovieRepository : RepositoryBase<LibraryContext>, IMovieRepository
    {
        public async Task<List<Movie>> GetAll()
        {
            using (var db = new LibraryContext())
            {
                return await db.Movies.ToListAsync();
            }
        }

        public async Task<List<Movie>> SearchMovies(string query, string sortOrder, int itemsPerPage, int pageToDisplay)
        {
            using (var db = new LibraryContext())
            {
                var movies = from m in db.Movies select m;

                if (!string.IsNullOrEmpty(query))
                {
                    movies = movies.Where(m => m.Title.Contains(query) || m.Genre.ToString() == query);
                }

                switch(sortOrder)
                {
                    case "title_desc":
                        movies = movies.OrderByDescending(m => m.Title);
                        break;
                    case "genre":
                        movies = movies.OrderBy(m => m.Genre);
                        break;
                    case "genre_desc":
                        movies = movies.OrderByDescending(m => m.Genre);
                        break;
                    default:
                        movies = movies.OrderBy(m => m.Title);
                        break;
                }
                return await movies.Include(q => q.Actor).Skip((pageToDisplay - 1) * itemsPerPage).Take(itemsPerPage).ToListAsync();
            }
        }

        public List<Movie> GetMostRecent()
        {
            using (var db = new LibraryContext())
            {
                //var movies = from m in db.Movies select m;

                return db.Movies.OrderByDescending(m => m.DateAdded).Include(q => q.Actor).Take(10).ToList();
            }
        }

        public List<string[]> GetDistributionByGenre()
        {
            using (var db = new LibraryContext())
            {
                var records = db.Movies.GroupBy(m => m.Genre);
                var result = new List<string[]>();
                foreach (var record in records)
                {
                    result.Add(new string[] { record.Key.ToString(), record.Count().ToString() });
                }

                //result = records.Select(r => new string[] { r.Key.ToString(), r.Count().ToString() }).ToList();
                return result;
            }
        }

        public async Task<Movie> Get(long? id)
        {
            using (var db = new LibraryContext())
            {
                return await db.Movies.Include(q => q.Actor).FirstOrDefaultAsync(p => p.Id == id);
            }
        }

        public List<Movie> GetMovies()
        {
            using (var db = new LibraryContext())
            {
                List<Movie> movies;

                #region Loading related entities

                // Lazy loading
                movies = db.Movies.ToList(); // First get all the movies
                foreach (var mov in movies)
                {
                    var actor = mov.Actor; // Database query is executed every time this line is hit
                    actor = db.Actors.Find(mov.LeadActorId); // This is unacceptable :)
                }

                // Eager loading
                movies = db.Movies.Include(m => m.Actor).ToList(); // All data loaded from database

                #endregion

                #region Minimise the Data Requested
                // Dont do this:
                movies = db.Movies.Include(q => q.Actor).ToList(); // Do you really need all the columns?

                // Do this instead
                movies = db.Movies.Include(q => q.Actor).Select(m => new Movie
                {
                    Id = m.Id,
                    Title = m.Title,
                    Actor = new Actor
                    {
                        Id = m.Actor.Id,
                        Name = m.Actor.Name
                    }
                }).ToList();
                #endregion

                #region Filter Before ToList()

                movies = db.Movies.ToList().Where(m => m.IsActive && m.Duration > 1).Take(50).ToList(); // ToList() executed too early
                movies = db.Movies.Where(m => m.IsActive && m.Duration > 1).Take(50).ToList(); // ToList() executed last

                #endregion

                #region Don’t Rely on Entity Framework Exclusively For Data Access

                movies = db.Database.SqlQuery<Movie>("select * from movies m join actors a on m.actorId = a.id").ToList();

                #endregion

                return movies;
            }
        }

        public int CountMovies()
        {
            using (var db = new LibraryContext())
            {
                #region Do Not Count After Query Execution

                int count = 0;
                count = db.Movies.Where(m => m.IsActive).ToList().Count; // returns all matching employees and then executes a count
                count = db.Movies.Count(m => m.IsActive); //only executes a SQL COUNT

                return count;

                #endregion

            }
        }

        public Movie GetMovie(int id)
        {
            throw new System.NotImplementedException();
        }

        public string SqlQuery()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteMovie(int id)
        {
            using (var db = new LibraryContext())
            {
                #region Don’t Load Entities To Delete Them

                // Executes a second hit to the database
                var movie = db.Movies.Find(id);
                if (movie != null)
                {
                    db.Movies.Remove(movie);
                    db.SaveChangesAsync();
                }

                // Executes a single hit to the database
                movie = new Movie { Id = id };
                db.Movies.Attach(movie);
                db.Movies.Remove(movie);
                db.SaveChanges();

                #endregion
            }
        }
    }


    public class MovieProjection
    {
        public string Title { get; set; }
    }
}
