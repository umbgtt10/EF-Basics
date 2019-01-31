namespace FluentApiExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameColumnToGenresTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "Name", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Genres", "Name");
        }
    }
}
