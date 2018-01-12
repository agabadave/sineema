using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.BorrowedMovieRepository
{
    public class BorrowedMovieRepository : IBorrowedMovieRepository
    {
        private readonly LibraryContext _db;

        public BorrowedMovieRepository(LibraryContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Add movie that has been borrowed.
        /// </summary>
        /// <param name="borrowedMovie">Movie borrowed.</param>
        /// <returns>Task result.</returns>
        public async Task AddBorrowedMovieAsync(BorrowedMovie borrowedMovie)
        {
            using (_db)
            {
                _db.BorrowedMovies.Add(borrowedMovie);
                await _db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// List all the borrowed movies.
        /// </summary>
        /// <returns>List of borrowed movies.</returns>
        public IQueryable<BorrowedMovie> GetAllBorrowedMovies()
        {
            using (_db)
            {
                return _db.BorrowedMovies;
            }
        }

        /// <summary>
        /// List all borrowed movies that have not been returned and their expected return date has passed.
        /// </summary>
        /// <param name="expectedReturnDate">Expected return date.</param>
        /// <returns>List of borrowed movies.</returns>
        public async Task<IEnumerable<BorrowedMovie>> GetBorrowedMoviesPastReturnDateAsync(DateTime expectedReturnDate)
        {
            return await GetAllBorrowedMovies()
                .Where(m => m.ExpectedReturnDate <= expectedReturnDate && m.ActualReturnDate == null).ToListAsync();
        }

        /// <summary>
        /// Remove borrowed movie.
        /// </summary>
        /// <param name="borrowedMovieId">Id of the borrowed movie.</param>
        /// <returns>Task result.</returns>
        public async Task RemoveBorrowedMovieAsync(Guid borrowedMovieId)
        {
            using (_db)
            {
                var movieToRemove = await _db.BorrowedMovies.SingleOrDefaultAsync(m => m.Id == borrowedMovieId);

                if (movieToRemove == null)
                {
                    throw new KeyNotFoundException($"Borrowed movie with Id {borrowedMovieId} was not found.");
                }

                _db.BorrowedMovies.Remove(movieToRemove);
                await _db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Update borrowed movie details.
        /// </summary>
        /// <param name="borrowedMovie">Borrowed movie update details.</param>
        /// <returns>Task result.</returns>
        public async Task UpdateBorrowedMovieAsync(BorrowedMovie borrowedMovie)
        {
            using (_db)
            {
                var movieToUpdate = await _db.BorrowedMovies.SingleOrDefaultAsync(m => m.Id == borrowedMovie.Id);

                if (movieToUpdate == null)
                {
                    throw new KeyNotFoundException($"Borrowed movie with Id {borrowedMovie.Id} was not found.");
                }

                movieToUpdate.ActualReturnDate = borrowedMovie.ActualReturnDate;
                movieToUpdate.DateBorrowed = borrowedMovie.DateBorrowed;
                movieToUpdate.ExpectedReturnDate = borrowedMovie.ExpectedReturnDate;

                _db.Entry(movieToUpdate).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
        }
    }
}
