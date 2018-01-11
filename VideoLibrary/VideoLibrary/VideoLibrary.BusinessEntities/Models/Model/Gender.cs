using System.ComponentModel.DataAnnotations.Schema;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    [Table("Gender")]
    public class Gender : ModelBase
    {
        public string Description { get; set; }
    }
}
