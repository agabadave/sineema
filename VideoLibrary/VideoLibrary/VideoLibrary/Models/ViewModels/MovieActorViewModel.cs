using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLibrary.Models.ViewModels
{
    public class MovieActorViewModel
    {
        public Guid MovieId { get; set; }
        public string MovieTitle { get; set; }
        public IEnumerable<MovieActorListViewModel> MovieActors { get; set; }
    }
}