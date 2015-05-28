namespace TrackaryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomProductsDict : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductDictionaries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Key_ID = c.Int(),
                        Cart_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.Key_ID)
                .ForeignKey("dbo.Carts", t => t.Cart_ID)
                .Index(t => t.Key_ID)
                .Index(t => t.Cart_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDictionaries", "Cart_ID", "dbo.Carts");
            DropForeignKey("dbo.ProductDictionaries", "Key_ID", "dbo.Products");
            DropIndex("dbo.ProductDictionaries", new[] { "Cart_ID" });
            DropIndex("dbo.ProductDictionaries", new[] { "Key_ID" });
            DropTable("dbo.ProductDictionaries");
        }
    }
}
