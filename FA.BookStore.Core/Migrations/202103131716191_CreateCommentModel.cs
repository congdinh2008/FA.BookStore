namespace FA.BookStore.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCommentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "common.Comment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(nullable: false, maxLength: 500),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsActive = c.Boolean(nullable: false),
                        BookId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("common.Book", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("common.Comment", "BookId", "common.Book");
            DropIndex("common.Comment", new[] { "BookId" });
            DropTable("common.Comment");
        }
    }
}
