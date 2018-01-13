using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLibrary.Models.ViewModels
{
    public class MovieListViewModel
    {
        public Guid MovieId { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public string DateAdded { get; set; }
        public int AddedBy { get; set; }
        public bool IsActive { get; set; }
    }
}