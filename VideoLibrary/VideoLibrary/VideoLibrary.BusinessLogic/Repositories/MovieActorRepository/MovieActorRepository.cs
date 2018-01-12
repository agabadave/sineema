using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.MovieActorRepository
{
    public class MovieActorRepository : IMovieActorRepository
    {

        public IQueryable<MovieActor> GetMovieActors(Guid movieId)
        {
            using (var db = new LibraryContext())
            {
                return db.MovieActors.Where(x => x.MovieId == movieId);
            }
        } 
    }
}
