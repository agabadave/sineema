using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLibrary.Models.ViewModels
{
    public class MovieDetailsViewModel
    {
        public Guid MovieId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public Guid GenreId { get; set; }
        public string Genre { get; set; }
    }
}