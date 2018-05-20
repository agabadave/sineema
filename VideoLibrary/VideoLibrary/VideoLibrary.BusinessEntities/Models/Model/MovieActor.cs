namespace VideoLibrary.BusinessEntities.Models.Model
{
    public class MovieActor : ModelBase
    {
        public string Role { get; set; }

        public int ActorId { get; set; }

        public Actor Actor { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
