using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    public class Movie : ModelBase
    {
        [Required]
        public string Title { get; set; }
        public int Duration { get; set; }
        public Genre Genre { get; set; }

        public long LeadActorId { get; set; }

        public virtual Actor Actor { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }

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
