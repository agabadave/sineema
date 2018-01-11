using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    [Table("Genre")]
    public class Genre : ModelBase
    {
        public string Title { get; set; }
    }
}
