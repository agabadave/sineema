﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoLibrary.Models.ViewModels
{
    public class ClientDetailsViewModel
    {
        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Guid? GenderId { get; set; }

        public string Fullname { get; set; }

        public IEnumerable<SelectListItem> GenderSelectList { get; set; }
    }
}