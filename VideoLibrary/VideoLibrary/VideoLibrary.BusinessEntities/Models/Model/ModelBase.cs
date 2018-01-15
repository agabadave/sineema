using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    public class ModelBase
    {
        [Required, Column(TypeName = "bit")]
        public bool IsActive { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime DateAdded { get; set; }

        [Required, Column(TypeName = "int")]
        public int AddedBy { get; set; }
    }
}
