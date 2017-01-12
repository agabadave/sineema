using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoLibrary.BusinessEntities.Models.Model
{
    public class Movie: ModelBase
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public Genre Genre { get; set; }
        
    }


    public enum Genre
    {
        Christian,
        Tteke,
        Masasi,
        Kinigeria,
        Kiyindi,
        Kinayuganda
    }
}
