using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    [Table("Client")]
    public partial class Client : ModelBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClientId { get; set; }

        [MaxLength(50), Column(TypeName = "varchar")]
        public string FirstName { get; set; }

        [MaxLength(50), Column(TypeName = "varchar")]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        public Guid? GenderId { get; set; }

        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }

        [NotMapped]
        public string Fullname { get { return $"{FirstName} {LastName}"; } }
    }
}
