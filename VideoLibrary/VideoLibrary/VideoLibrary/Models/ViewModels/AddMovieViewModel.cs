using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoLibrary.Models.ViewModels
{
    public class AddMovieViewModel
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public Guid GenreId { get; set; }
        public IEnumerable<SelectListItem> GenreSelectList { get; set; }
    }
}