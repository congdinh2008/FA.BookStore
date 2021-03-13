namespace FA.BookStore.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBookModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("common.Book", "Summary", c => c.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("common.Book", "Summary", c => c.String(maxLength: 1024));
        }
    }
}
