using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    public partial class Client
    {

        public string Name { get { return FirstName + " " + LastName; } }
    }
}
