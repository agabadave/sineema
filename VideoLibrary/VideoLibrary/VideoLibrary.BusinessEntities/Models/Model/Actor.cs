using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    [Table("Actor")]
    public class Actor: ModelBase
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Guid? GenderId { get; set; }

        public Guid? GenreId { get; set; }

        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        [NotMapped]
        public string Fullname { get { return $"{Firstname} {Lastname}"; } }
    }


}
