using System.Data.Entity.Migrations;

namespace VideoLibrary.BusinessEntities.Migrations
{

    public partial class AddGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actor", "Genre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actor", "Genre");
        }
    }
}
