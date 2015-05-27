namespace TrackaryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorCartSessions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.Products", "Cart_ID", "dbo.Carts");
            DropIndex("dbo.Carts", new[] { "Customer_ID" });
            DropIndex("dbo.Products", new[] { "Cart_ID" });
            CreateTable(
                "dbo.CartSessionDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Products", "CartSessionData_ID", c => c.Int());
            CreateIndex("dbo.Products", "CartSessionData_ID");
            AddForeignKey("dbo.Products", "CartSessionData_ID", "dbo.CartSessionDatas", "ID");
            DropColumn("dbo.Products", "Cart_ID");
            DropTable("dbo.Carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TransactionDateTime = c.DateTime(nullable: false),
                        CheckedOut = c.Boolean(nullable: false),
                        Customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Products", "Cart_ID", c => c.Int());
            DropForeignKey("dbo.Products", "CartSessionData_ID", "dbo.CartSessionDatas");
            DropIndex("dbo.Products", new[] { "CartSessionData_ID" });
            DropColumn("dbo.Products", "CartSessionData_ID");
            DropTable("dbo.CartSessionDatas");
            CreateIndex("dbo.Products", "Cart_ID");
            CreateIndex("dbo.Carts", "Customer_ID");
            AddForeignKey("dbo.Products", "Cart_ID", "dbo.Carts", "ID");
            AddForeignKey("dbo.Carts", "Customer_ID", "dbo.Customers", "ID");
        }
    }
}
