﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    public class Actor: ModelBase
    {
        [Required]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        public Gender Gender { get; set; }

        public String Genre { get; set; }
        public int NumberOfMovies { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }
    }


}
