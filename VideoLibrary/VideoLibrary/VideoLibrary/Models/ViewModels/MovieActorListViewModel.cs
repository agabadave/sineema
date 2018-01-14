using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLibrary.Models.ViewModels
{
    public class MovieActorListViewModel
    {
        public Guid MovieActorId { get; set; }
        public Guid ActorId { get; set; }
        public string Fullname { get; set; }
        public string Role { get; set; }
        public bool LeadActor { get; set; }
    }
}