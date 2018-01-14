using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLibrary.Models.ViewModels
{
    public class ActorViewModel
    {
        public Guid ActorId { get; set; }
        public string DateOfBirth { get; set; }
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public Guid GenderId { get; set; }
        public string Genre { get; set; }
        public Guid GenreId { get; set; }
    }
}