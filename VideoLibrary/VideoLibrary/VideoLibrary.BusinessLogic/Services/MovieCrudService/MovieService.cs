using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;
using VideoLibrary.BusinessLogic.Repositories.MovieRepository;

namespace VideoLibrary.BusinessLogic.Services.MovieCrudService
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _movieRepository.GetAllMovies().ToListAsync();
        }

        public async Task<Movie> GetMovieDetails(Guid id)
        {
            return await _movieRepository.GetMovieByIdAsync(id);
        }

        public async Task DeleteMovie(Guid id)
        {
            await _movieRepository.RemoveMovieAsync(id);
        }

        public async Task<Movie> InsertMovie(Movie model)
        {
            return await _movieRepository.AddMovieAsync(model);
        }

        public async Task<Movie> UpdateMovie(Movie model)
        {
            return await _movieRepository.UpdateMovieAsync(model);
        }
    }
}