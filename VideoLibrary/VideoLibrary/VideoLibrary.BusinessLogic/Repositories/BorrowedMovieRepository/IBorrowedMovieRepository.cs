using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.BorrowedMovieRepository
{
    public interface IBorrowedMovieRepository
    {
        Task AddBorrowedMovieAsync(BorrowedMovie borrowedMovie);
        Task UpdateBorrowedMovieAsync(BorrowedMovie borrowedMovie);
        Task RemoveBorrowedMovieAsync(Guid borrowedMovieId);
        IQueryable<BorrowedMovie> GetAllBorrowedMovies();
        Task<IEnumerable<BorrowedMovie>> GetBorrowedMoviesPastReturnDateAsync(DateTime expectedReturnDate);
    }
}
