using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoLibrary.Models.ViewModels
{
    public class AddMovieActorViewModel
    {
        public Guid MovieId { get; set; }
        public string Movie { get; set; }
        public Guid ActorId { get; set; }
        public string Role { get; set; }
        public bool LeadActor { get; set; }
        public IEnumerable<SelectListItem> ActorSelectList { get; set; }
    }
}