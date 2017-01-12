using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    public class Actor: ModelBase
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }


}
