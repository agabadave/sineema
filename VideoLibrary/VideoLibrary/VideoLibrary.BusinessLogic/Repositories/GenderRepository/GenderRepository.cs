using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.GenderRepository
{
    public class GenderRepository : IGenderRepository
    {
        private readonly LibraryContext _db;

        public GenderRepository(LibraryContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Add gender.
        /// </summary>
        /// <param name="gender">Gender to be added.</param>
        /// <returns>Task result.</returns>
        public async Task AddGenderAsync(Gender gender)
        {
            _db.Genders.Add(gender);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// List all genders.
        /// </summary>
        /// <returns>List of genders.</returns>
        public async Task<IEnumerable<Gender>> GetAllGenders()
        {
            return await _db.Genders.ToListAsync();
        }

        /// <summary>
        /// Get gender by Id.
        /// </summary>
        /// <param name="genderId">Gender Id.</param>
        /// <returns>Gender.</returns>
        public async Task<Gender> GetGenderById(Guid genderId)
        {
            return (await GetAllGenders()).SingleOrDefault(g => g.GenderId == genderId);
        }

        /// <summary>
        /// Remove gender.
        /// </summary>
        /// <param name="genderId">Gender Id.</param>
        /// <returns>Task result</returns>
        public async Task RemoveGenderAsync(Guid genderId)
        {
            var genderToRemove = await GetGenderById(genderId);

            if (genderToRemove == null)
            {
                throw new KeyNotFoundException($"Gender with Id {genderId} was not found.");
            }

            _db.Genders.Remove(genderToRemove);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Update gender.
        /// </summary>
        /// <param name="gender">Gender update.</param>
        /// <returns>Task result.</returns>
        public async Task UpdateGenderAsync(Gender gender)
        {
            var genderToUpdate = await GetGenderById(gender.GenderId);

            if (genderToUpdate == null)
            {
                throw new KeyNotFoundException($"Gender with Id {gender.GenderId} was not found.");
            }

            genderToUpdate.Description = gender.Description;

            _db.Entry(genderToUpdate).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
