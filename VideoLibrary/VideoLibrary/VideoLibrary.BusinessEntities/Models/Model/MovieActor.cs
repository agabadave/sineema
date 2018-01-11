using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    [Table("MovieActor")]
    public class MovieActor : ModelBase
    {
        public string Role { get; set; }

        public bool LeadActor { get; set; }

        public Guid ActorId { get; set; }

        public Guid MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        [ForeignKey("ActorId")]
        public Actor Actor { get; set; }
    }
}
