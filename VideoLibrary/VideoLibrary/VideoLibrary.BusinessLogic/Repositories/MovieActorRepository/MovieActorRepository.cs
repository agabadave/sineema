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
        private LibraryContext _db;

        public MovieActorRepository(LibraryContext context)
        {
            _db = context;
        }

        public IQueryable<MovieActor> GetMovieActors(Guid movieId)
        {
            return _db.MovieActors.Where(x => x.MovieId == movieId);
        } 
    }
}
