namespace FluentApiExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverridingCodeFirstConventions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Videos", "Genres_Id", "dbo.Genres");
            DropIndex("dbo.Videos", new[] { "Genres_Id" });
            RenameColumn(table: "dbo.Videos", name: "Genres_Id", newName: "GenreId");
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Videos", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Videos", "Classification", c => c.Byte(nullable: false));
            AlterColumn("dbo.Videos", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Videos", "GenreId");
            AddForeignKey("dbo.Videos", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "GenreId", "dbo.Genres");
            DropIndex("dbo.Videos", new[] { "GenreId" });
            AlterColumn("dbo.Videos", "GenreId", c => c.Int());
            AlterColumn("dbo.Videos", "Classification", c => c.Int());
            AlterColumn("dbo.Videos", "Name", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            RenameColumn(table: "dbo.Videos", name: "GenreId", newName: "Genres_Id");
            CreateIndex("dbo.Videos", "Genres_Id");
            AddForeignKey("dbo.Videos", "Genres_Id", "dbo.Genres", "Id");
        }
    }
}
