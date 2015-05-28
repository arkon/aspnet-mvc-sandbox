namespace TrackaryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transactions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TransactionDateTime = c.DateTime(nullable: false),
                        Cart_ID = c.Int(),
                        Customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Carts", t => t.Cart_ID)
                .ForeignKey("dbo.Customers", t => t.Customer_ID)
                .Index(t => t.Cart_ID)
                .Index(t => t.Customer_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "Cart_ID", "dbo.Carts");
            DropIndex("dbo.Transactions", new[] { "Customer_ID" });
            DropIndex("dbo.Transactions", new[] { "Cart_ID" });
            DropTable("dbo.Transactions");
        }
    }
}
