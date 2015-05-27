namespace TrackaryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "TransactionDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Carts", "CheckedOut", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "CheckedOut");
            DropColumn("dbo.Carts", "TransactionDateTime");
        }
    }
}
