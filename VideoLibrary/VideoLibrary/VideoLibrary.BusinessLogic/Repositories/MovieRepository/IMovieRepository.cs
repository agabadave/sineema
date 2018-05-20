using System.Collections.Generic;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.MovieRepository
{
    public interface IMovieRepository: IRepositoryBase
    {
        Task<List<Movie>> GetAll();
        Task<Movie> Get(long? id);
        List<Movie> GetMostRecent();
        List<string[]> GetDistributionByGenre();
        List<Movie> GetMovies();
        int CountMovies();
        Movie GetMovie(int id);
        string SqlQuery();

        void DeleteMovie(int id);
        Task<List<Movie>> SearchMovies(string query, string sortOrder, int itemsPerPage, int pageToDisplay);
    }
}
