using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLibrary.Models.ViewModels
{
    public class DeleteMovieViewModel
    {
        public Guid MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
    }
}