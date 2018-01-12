using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    [Table("BorrowedMovie")]
    public class BorrowedMovie : ModelBase
    {
        public Guid? MovieId { get; set; }

        public Guid? ClientId { get; set; }

        public DateTime? DateBorrowed { get; set; }

        public DateTime? ExpectedReturnDate { get; set; }

        public DateTime? ActualReturnDate { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
    }
}
