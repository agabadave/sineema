using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoLibrary.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public int? AddedBy { get; set; }

        public BaseEntity()
        {
            DateAdded = DateTime.UtcNow;
        }
    }
}