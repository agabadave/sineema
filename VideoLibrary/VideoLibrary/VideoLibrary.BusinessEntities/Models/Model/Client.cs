using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    public partial class Client : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}
