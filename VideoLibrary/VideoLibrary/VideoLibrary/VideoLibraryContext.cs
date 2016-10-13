using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VideoLibrary.Models;

namespace VideoLibrary
{
    public class VideoLibraryContext : DbContext
    {
        public VideoLibraryContext() : base("name=VideoLibraryContext") { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; } 
    }
}