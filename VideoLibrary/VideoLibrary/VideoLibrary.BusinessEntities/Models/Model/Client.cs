using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    [Table("Client")]
    public partial class Client : ModelBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Guid? GenderId { get; set; }

        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }
    }
}
