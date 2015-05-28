namespace TrackaryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTransaction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Cart_ID", "dbo.Carts");
            DropIndex("dbo.Transactions", new[] { "Cart_ID" });
            AddColumn("dbo.Transactions", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transactions", "Items", c => c.String());
            DropColumn("dbo.Transactions", "Cart_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Cart_ID", c => c.Int());
            DropColumn("dbo.Transactions", "Items");
            DropColumn("dbo.Transactions", "Amount");
            CreateIndex("dbo.Transactions", "Cart_ID");
            AddForeignKey("dbo.Transactions", "Cart_ID", "dbo.Carts", "ID");
        }
    }
}
