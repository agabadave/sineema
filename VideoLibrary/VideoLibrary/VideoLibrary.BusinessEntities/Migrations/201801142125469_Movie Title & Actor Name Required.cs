namespace VideoLibrary.BusinessEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieTitleActorNameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actor", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Actor", "Name", c => c.String());
        }
    }
}
