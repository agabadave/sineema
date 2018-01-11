using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    [Table("Movie")]
    public class Movie : ModelBase
    {
        public string Title { get; set; }

        public int Duration { get; set; }

        public Guid? GenreId { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

    }
}
