using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoLibrary.Models.ViewModels
{
    public class ClientDeleteViewModel
    {
        [Required]
        public Guid ClientId { get; set; }

        public string Fullname { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [Display(Name = "Date of birth")]
        public string DateOfBirth { get; set; }

        public string Gender { get; set; }
    }
}