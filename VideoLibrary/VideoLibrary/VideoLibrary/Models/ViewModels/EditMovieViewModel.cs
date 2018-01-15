using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoLibrary.Models.ViewModels
{
    public class EditMovieViewModel
    {
        public Guid MovieId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public Guid GenreId { get; set; }
        public IEnumerable<SelectListItem> GenreSelectList { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public int AddedBy { get; set; }
    }
}