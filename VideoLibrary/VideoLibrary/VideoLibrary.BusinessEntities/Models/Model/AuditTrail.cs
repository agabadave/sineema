using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    [Table("AuditTrail")]
    public class AuditTrail : ModelBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MaxLength(256), Column(TypeName = "varchar")]
        public string TableName { get; set; }

        [MaxLength(256), Column(TypeName = "varchar")]
        public string UserName { get; set; }

        [MaxLength(256), Column(TypeName = "varchar")]
        public string Actions { get; set; }

        [MaxLength(256), Column(TypeName = "varchar")]
        public string OldData { get; set; }

        [MaxLength(256), Column(TypeName = "varchar")]
        public string NewData { get; set; }

        [MaxLength(256), Column(TypeName = "varchar")]
        public string ChangedColums { get; set; }

        [MaxLength(256), Column(TypeName = "varchar")]
        public string TableIdValue { get; set; }

    }
}
