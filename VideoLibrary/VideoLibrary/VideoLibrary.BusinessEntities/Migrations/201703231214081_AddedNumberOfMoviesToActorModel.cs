using System.Data.Entity.Migrations;

namespace VideoLibrary.BusinessEntities.Migrations
{

    public partial class AddedNumberOfMoviesToActorModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actor", "NumberOfMovies", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actor", "NumberOfMovies");
        }
    }
}
