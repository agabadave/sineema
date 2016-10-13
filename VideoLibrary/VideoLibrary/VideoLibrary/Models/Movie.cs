using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoLibrary.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
        public Genre Genre { get; set; }

    }

    public enum Genre
    {
        Christian,
        Tteke,
        Masasi,
        Kinigeria,
        Kiyindi,
        Kinayuganda
    }
}