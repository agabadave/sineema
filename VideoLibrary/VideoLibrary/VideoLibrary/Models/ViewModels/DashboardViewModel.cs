using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLibrary.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int BorrowedMovies { get; set; }
        public int MoviesCount { get; set; }

        public IEnumerable<Dictionary<string, int>> MoviesCountByGenre { get; set; }
        public IEnumerable<Dictionary<string, int>> MoviesCountByActor { get; set; }
    }
}