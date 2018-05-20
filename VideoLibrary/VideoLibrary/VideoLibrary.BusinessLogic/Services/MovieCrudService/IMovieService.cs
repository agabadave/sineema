﻿using System.Collections.Generic;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Services.MovieCrudService
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMovies();
        List<Movie> GetRecent();
        List<string[]> GetDistributionByGenre();
        Task<Movie> GetMovieDetails(long? id);
        Task<Movie> DeleteMovie(long? id);
        Task<Movie> GetMovie(long? id);
        Task<Movie> InsertMovie(Movie model);
        Task<Movie> UpdateMovie(Movie model);
        Task<List<Movie>> SearchMovies(string query, string sortOrder, int itemsPerPage, int pageToDisplay);
    }
}
