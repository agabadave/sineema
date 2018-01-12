using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessLogic.Repositories.GenderRepository
{
    public interface IGenderRepository
    {
        Task AddGenderAsync(Gender gender);

        Task UpdateGenderAsync(Gender gender);

        Task RemoveGenderAsync(Guid genderId);

        Task<Gender> GetGenderById(Guid genderId);

        IQueryable<Gender> GetAllGenders();
    }
}
