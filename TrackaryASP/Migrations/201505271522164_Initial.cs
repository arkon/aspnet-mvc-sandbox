namespace TrackaryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.Customer_ID)
                .Index(t => t.Customer_ID);
            
            AddColumn("dbo.Products", "Cart_ID", c => c.Int());
            CreateIndex("dbo.Products", "Cart_ID");
            AddForeignKey("dbo.Products", "Cart_ID", "dbo.Carts", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Cart_ID", "dbo.Carts");
            DropForeignKey("dbo.Carts", "Customer_ID", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "Cart_ID" });
            DropIndex("dbo.Carts", new[] { "Customer_ID" });
            DropColumn("dbo.Products", "Cart_ID");
            DropTable("dbo.Carts");
        }
    }
}
