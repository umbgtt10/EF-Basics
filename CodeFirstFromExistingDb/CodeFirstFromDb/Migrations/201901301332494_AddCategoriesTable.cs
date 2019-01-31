namespace CodeFirstFromDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO Categories Values (1, 'Web Development' )");
            Sql("INSERT INTO Categories Values (2, 'Programming Language' )");
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
