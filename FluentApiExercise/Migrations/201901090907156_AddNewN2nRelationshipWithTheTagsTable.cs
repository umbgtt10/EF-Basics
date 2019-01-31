namespace FluentApiExercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewN2nRelationshipWithTheTagsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VideoTags",
                c => new
                    {
                        VideoId = c.Int(nullable: false),
                        TagsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VideoId, t.TagsId })
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagsId, cascadeDelete: true)
                .Index(t => t.VideoId)
                .Index(t => t.TagsId);            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoTags", "TagsId", "dbo.Tags");
            DropForeignKey("dbo.VideoTags", "VideoId", "dbo.Videos");
            DropIndex("dbo.VideoTags", new[] { "TagsId" });
            DropIndex("dbo.VideoTags", new[] { "VideoId" });
            DropTable("dbo.VideoTags");
            DropTable("dbo.Tags");
        }
    }
}
