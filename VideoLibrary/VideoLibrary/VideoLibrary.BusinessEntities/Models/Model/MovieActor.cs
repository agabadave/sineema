using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    [Table("MovieActor")]
    public class MovieActor : ModelBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MovieActorId { get; set; }

        [MaxLength(50), Column(TypeName = "varchar")]
        public string Role { get; set; }

        [Column(TypeName = "bit")]
        public bool? LeadActor { get; set; }

        public Guid? ActorId { get; set; }

        public Guid? MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        [ForeignKey("ActorId")]
        public Actor Actor { get; set; }
    }
}
