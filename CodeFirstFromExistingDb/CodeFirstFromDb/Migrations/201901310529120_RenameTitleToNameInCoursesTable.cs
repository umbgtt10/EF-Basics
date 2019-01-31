namespace CodeFirstFromDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTitleToNameInCoursesTable : DbMigration
    {
        public override void Up()
        {
            // The following generated code would be too dangerous
            // AddColumn("dbo.Courses", "Name", c => c.String(nullable:false));
            // Alternative: Sql("UPDATE Courses SET Name = Title");
            // DropColumn("dbo.Courses", "Title");
            RenameColumn("dbo.Courses", "Title", "Name");            
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Courses", "Name", "Title");
            // The following generated code would be too dangerous
            // AddColumn("dbo.Courses", "Title", c => c.String());
            // Alternative: Sql("UPDATE Courses SET Title = Name");
            // DropColumn("dbo.Courses", "Name");
        }
    }
}
