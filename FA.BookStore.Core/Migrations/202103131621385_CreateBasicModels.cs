namespace FA.BookStore.Core.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateBasicModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "common.Author",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    Description = c.String(maxLength: 1024),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "common.Book",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Title = c.String(nullable: false, maxLength: 255),
                    Summary = c.String(maxLength: 1024),
                    ImageUrl = c.String(nullable: false),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Quantity = c.Int(nullable: false),
                    CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                    IsActive = c.Boolean(nullable: false),
                    CategoryId = c.Guid(nullable: false),
                    AuthorId = c.Guid(nullable: false),
                    PublisherId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("common.Author", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("common.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("common.Publisher", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.AuthorId)
                .Index(t => t.PublisherId);

            CreateTable(
                "common.Category",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    Description = c.String(maxLength: 1024),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "common.Publisher",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    Description = c.String(maxLength: 1024),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("common.Book", "PublisherId", "common.Publisher");
            DropForeignKey("common.Book", "CategoryId", "common.Category");
            DropForeignKey("common.Book", "AuthorId", "common.Author");
            DropIndex("common.Book", new[] { "PublisherId" });
            DropIndex("common.Book", new[] { "AuthorId" });
            DropIndex("common.Book", new[] { "CategoryId" });
            DropTable("common.Publisher");
            DropTable("common.Category");
            DropTable("common.Book");
            DropTable("common.Author");
        }
    }
}
