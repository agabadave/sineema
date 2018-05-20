using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    public class Movie : ModelBase
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Duration (mins)")]
        public int Duration { get; set; }
        public Genre Genre { get; set; }

        [Display(Name = "Lead Actor")]
        public long LeadActorId { get; set; }

        [Display(Name = "Actor")]
        [ForeignKey("LeadActorId")]
        public Actor Actor { get; set; }

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
