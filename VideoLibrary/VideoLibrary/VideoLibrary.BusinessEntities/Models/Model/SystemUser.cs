using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    public class  SystemUser : ModelBase
    {
       
        [Required(ErrorMessage = "Field can't be empty")]
        public string UserName{ get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
