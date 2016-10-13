using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLibrary.Models
{
    public class Client : BaseEntity
    {   
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Godwin,
        Kenneth
    }
}