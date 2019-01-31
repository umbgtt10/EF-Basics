namespace FluentApiExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveN2nRelationshipFromVideosAndGenresTables : DbMigration
    {
        public override void Up()
        {
            // Added statement
            CreateTable(
                "dbo._VideoGenres",
                c => new
                {
                    Video_Id = c.Int(nullable: false),
                    Genre_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Video_Id, t.Genre_Id });
            // Added statement
            Sql("INSERT INTO dbo._VideoGenres (Video_Id, Genre_Id) SELECT Video_Id, Genre_Id FROM dbo.VideoGenres");

            DropForeignKey("dbo.VideoGenres", "Video_Id", "dbo.Videos");
            DropForeignKey("dbo.VideoGenres", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.VideoGenres", new[] { "Video_Id" });
            DropIndex("dbo.VideoGenres", new[] { "Genre_Id" });
            AddColumn("dbo.Videos", "Genres_Id", c => c.Int());
            CreateIndex("dbo.Videos", "Genres_Id");
            AddForeignKey("dbo.Videos", "Genres_Id", "dbo.Genres", "Id");
            DropTable("dbo.VideoGenres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VideoGenres",
                c => new
                    {
                        Video_Id = c.Int(nullable: false),
                        Genre_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Video_Id, t.Genre_Id });
            
            DropForeignKey("dbo.Videos", "Genres_Id", "dbo.Genres");
            DropIndex("dbo.Videos", new[] { "Genres_Id" });
            DropColumn("dbo.Videos", "Genres_Id");
            CreateIndex("dbo.VideoGenres", "Genre_Id");
            CreateIndex("dbo.VideoGenres", "Video_Id");
            AddForeignKey("dbo.VideoGenres", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VideoGenres", "Video_Id", "dbo.Videos", "Id", cascadeDelete: true);
            // Added statement
            Sql("INSERT INTO dbo.VideoGenres (Video_Id, Genre_Id) SELECT Video_Id, Genre_Id FROM dbo._VideoGenres");
            // Added statement
            DropTable("dbo._VideoGenres");
        }
    }
}
