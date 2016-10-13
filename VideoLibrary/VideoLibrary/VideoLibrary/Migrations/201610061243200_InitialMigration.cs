namespace VideoLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        AddedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        AddedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Duration = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                        Genre = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        AddedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .Index(t => t.ActorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "ActorId", "dbo.Actors");
            DropIndex("dbo.Movies", new[] { "ActorId" });
            DropTable("dbo.Movies");
            DropTable("dbo.Clients");
            DropTable("dbo.Actors");
        }
    }
}
