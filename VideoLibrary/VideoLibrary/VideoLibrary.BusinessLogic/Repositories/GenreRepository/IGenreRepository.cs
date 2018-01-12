using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.GenreRepository
{
    public interface IGenreRepository
    {
        Task AddGenreAsync(Genre genre);
        Task UpdateGenreAsync(Genre genre);
        Task<Genre> GetGenreById(Guid genreId);
        IQueryable<Genre> GetAllGenres();
    }
}
