namespace Exercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReferenceDataToTables : DbMigration
    {
        public override void Up()
        {            
            Sql("INSERT INTO Videos VALUES(1, 'video1','2018-09-01 10:10:10')");
            Sql("INSERT INTO Genres VALUES(1, 'genre1')");
            Sql("INSERT INTO VideoGenres VALUES(1, 1)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM VideoGenres WHERE Video_Id = 1");
            Sql("DELETE FROM Genres WHERE Id = 1");
            Sql("DELETE FROM Videos WHERE Id = 1");
        }
    }
}
