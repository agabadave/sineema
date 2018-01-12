using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Services.MovieCrudService
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovieDetails(Guid id);
        Task DeleteMovie(Guid id);
        Task<Movie> InsertMovie(Movie model);
        Task<Movie> UpdateMovie(Movie model);
    }
}
