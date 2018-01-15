using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    [Table("Movie")]
    public class Movie : ModelBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MovieId { get; set; }

        [MaxLength(100), Column(TypeName = "varchar")]
        public string Title { get; set; }
        
        [Column(TypeName = "int")]
        public int? Duration { get; set; }

        public Guid? GenreId { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

    }
}
