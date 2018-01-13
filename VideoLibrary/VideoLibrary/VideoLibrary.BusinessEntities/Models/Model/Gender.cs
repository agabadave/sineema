using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    [Table("Gender")]
    public class Gender : ModelBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GenderId { get; set; }

        [MaxLength(20), Column(TypeName = "varchar")]
        public string Description { get; set; }
    }
}
