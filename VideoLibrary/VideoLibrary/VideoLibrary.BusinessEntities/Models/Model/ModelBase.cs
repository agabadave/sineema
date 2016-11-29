using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    public class ModelBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public bool IsActive
        {
            get { return _isActive ?? true; }
            set { _isActive = value; }
        }

        public DateTime DateAdded
        {
            get { return _dateCreated ?? DateTime.Now; }
            set { _dateCreated = value; }
        }
        
        public int? AddedBy { get; set; }


        private DateTime? _dateCreated;
        private Boolean? _isActive;
    }
}
