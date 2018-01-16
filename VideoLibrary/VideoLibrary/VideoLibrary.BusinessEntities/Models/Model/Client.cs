using System;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    public  class Client : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}
