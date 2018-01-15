using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoLibrary.Models.ViewModels
{
    public class ClientListViewModel
    {
        public Guid ClientId { get; set; }
        [Display(Name = "Date of birth")]
        public string DateOfBirth { get; set; }
        public string Fullname { get; set; }
        public string Gender { get; set; }
    }
}