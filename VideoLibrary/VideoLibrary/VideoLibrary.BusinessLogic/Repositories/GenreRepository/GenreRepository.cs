using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.GenreRepository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly LibraryContext _db;

        public GenreRepository(LibraryContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Add genre.
        /// </summary>
        /// <param name="genre">Genre to add.</param>
        /// <returns>Task result.</returns>
        public async Task AddGenreAsync(Genre genre)
        {
            _db.Genres.Add(genre);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// List all genres.
        /// </summary>
        /// <returns>List of genres.</returns>
        public IQueryable<Genre> GetAllGenres()
        {
            return _db.Genres;
        }

        /// <summary>
        /// Get genre by Id.
        /// </summary>
        /// <param name="genreId">Genre Id.</param>
        /// <returns>Genre</returns>
        public async Task<Genre> GetGenreById(Guid genreId)
        {
            return await GetAllGenres().SingleOrDefaultAsync(g => g.GenreId == genreId);
        }

        /// <summary>
        /// Update genre.
        /// </summary>
        /// <param name="genre">Genre updates.</param>
        /// <returns>Task result.</returns>
        public async Task UpdateGenreAsync(Genre genre)
        {
            var genreToUpdate = await GetGenreById(genre.GenreId);

            if (genreToUpdate == null)
            {
                throw new KeyNotFoundException($"Genre with Id {genre.GenreId} was not found.");
            }

            genreToUpdate.Title = genre.Title;

            _db.Entry(genreToUpdate).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
