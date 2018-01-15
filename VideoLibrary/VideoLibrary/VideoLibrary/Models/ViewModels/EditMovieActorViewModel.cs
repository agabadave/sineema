using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLibrary.Models.ViewModels
{
    public class EditMovieActorViewModel
    {
        public Guid MovieActorId { get; set; }
        public string Role { get; set; }
        public bool LeadActor { get; set; }
        public string ActorFullname { get; set; }
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }
        public string MovieTitle { get; set; }
    }
}