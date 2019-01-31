namespace FluentApiExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReleaseDateSetToNullableinVideosTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Videos", "ReleaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Videos", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
