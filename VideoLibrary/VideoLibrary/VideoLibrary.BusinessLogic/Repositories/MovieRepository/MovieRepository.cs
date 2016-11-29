using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.MovieRepository
{
    public class MovieRepository : RepositoryBase<LibraryContext>, IMovieRepository
    {
        public async Task<List<Movie>> GetAll()
        {
            using (var db = new LibraryContext())
            {


                return await db.Movies.Include(i => i.Actor).ToListAsync();
            }
        }

        public async Task<Movie> Get(long? id)
        {
            using (var db = new LibraryContext())
            {
                return await db.Movies.Include(i => i.Actor).FirstOrDefaultAsync(p => p.Id == id);
            }
        }
    }


    public class MovieProjection
    {
        public string Title { get; set; }
    }
}
