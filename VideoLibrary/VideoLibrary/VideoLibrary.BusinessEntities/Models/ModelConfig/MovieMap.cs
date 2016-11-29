using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.BusinessEntities.Models.ModelConfig
{
    public class MovieMap : EntityTypeConfiguration<Movie>
    {
        public MovieMap()
        {
            Property(p => p.Title).IsRequired();
            Property(p => p.ActorId).IsRequired();
           
            
            HasRequired(p => p.Actor).WithMany(p => p.Movies).HasForeignKey(f => f.ActorId);


        }
    }
}
