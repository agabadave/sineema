namespace VideoLibrary.BusinessEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchemaChange_JGS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actor",
                c => new
                    {
                        ActorId = c.Guid(nullable: false, identity: true),
                        Firstname = c.String(maxLength: 50, unicode: false),
                        Lastname = c.String(maxLength: 50, unicode: false),
                        DateOfBirth = c.DateTime(storeType: "date"),
                        GenderId = c.Guid(),
                        GenreId = c.Guid(),
                        IsActive = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false, storeType: "date"),
                        AddedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActorId)
                .ForeignKey("dbo.Gender", t => t.GenderId)
                .ForeignKey("dbo.Genre", t => t.GenreId)
                .Index(t => t.GenderId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        GenderId = c.Guid(nullable: false, identity: true),
                        Description = c.String(maxLength: 20, unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false, storeType: "date"),
                        AddedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreId = c.Guid(nullable: false, identity: true),
                        Title = c.String(maxLength: 50, unicode: false),
                        IsActive = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false, storeType: "date"),
                        AddedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.AuditTrails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TableName = c.String(),
                        UserName = c.String(),
                        Actions = c.String(),
                        OldData = c.String(),
                        NewData = c.String(),
                        ChangedColums = c.String(),
                        TableIdValue = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false, storeType: "date"),
                        AddedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BorrowedMovie",
                c => new
                    {
                        BorrowedMovieId = c.Guid(nullable: false, identity: true),
                        MovieId = c.Guid(),
                        ClientId = c.Guid(),
                        DateBorrowed = c.DateTime(storeType: "date"),
                        ExpectedReturnDate = c.DateTime(storeType: "date"),
                        ActualReturnDate = c.DateTime(storeType: "date"),
                        IsActive = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false, storeType: "date"),
                        AddedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BorrowedMovieId)
                .ForeignKey("dbo.Client", t => t.ClientId)
                .ForeignKey("dbo.Movie", t => t.MovieId)
                .Index(t => t.MovieId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientId = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50, unicode: false),
                        LastName = c.String(maxLength: 50, unicode: false),
                        DateOfBirth = c.DateTime(storeType: "date"),
                        GenderId = c.Guid(),
                        IsActive = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false, storeType: "date"),
                        AddedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Gender", t => t.GenderId)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        MovieId = c.Guid(nullable: false, identity: true),
                        Title = c.String(maxLength: 100, unicode: false),
                        Duration = c.Int(),
                        GenreId = c.Guid(),
                        IsActive = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false, storeType: "date"),
                        AddedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.Genre", t => t.GenreId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.MovieActor",
                c => new
                    {
                        MovieActorId = c.Guid(nullable: false, identity: true),
                        Role = c.String(maxLength: 50, unicode: false),
                        LeadActor = c.Boolean(),
                        ActorId = c.Guid(),
                        MovieId = c.Guid(),
                        IsActive = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false, storeType: "date"),
                        AddedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieActorId)
                .ForeignKey("dbo.Actor", t => t.ActorId)
                .ForeignKey("dbo.Movie", t => t.MovieId)
                .Index(t => t.ActorId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieActor", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieActor", "ActorId", "dbo.Actor");
            DropForeignKey("dbo.BorrowedMovie", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Movie", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.BorrowedMovie", "ClientId", "dbo.Client");
            DropForeignKey("dbo.Client", "GenderId", "dbo.Gender");
            DropForeignKey("dbo.Actor", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Actor", "GenderId", "dbo.Gender");
            DropIndex("dbo.MovieActor", new[] { "MovieId" });
            DropIndex("dbo.MovieActor", new[] { "ActorId" });
            DropIndex("dbo.Movie", new[] { "GenreId" });
            DropIndex("dbo.Client", new[] { "GenderId" });
            DropIndex("dbo.BorrowedMovie", new[] { "ClientId" });
            DropIndex("dbo.BorrowedMovie", new[] { "MovieId" });
            DropIndex("dbo.Actor", new[] { "GenreId" });
            DropIndex("dbo.Actor", new[] { "GenderId" });
            DropTable("dbo.MovieActor");
            DropTable("dbo.Movie");
            DropTable("dbo.Client");
            DropTable("dbo.BorrowedMovie");
            DropTable("dbo.AuditTrails");
            DropTable("dbo.Genre");
            DropTable("dbo.Gender");
            DropTable("dbo.Actor");
        }
    }
}
