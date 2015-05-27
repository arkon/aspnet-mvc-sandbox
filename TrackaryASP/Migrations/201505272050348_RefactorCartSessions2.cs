namespace TrackaryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorCartSessions2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CartSessionDatas", newName: "Carts");
            RenameColumn(table: "dbo.Products", name: "CartSessionData_ID", newName: "Cart_ID");
            RenameIndex(table: "dbo.Products", name: "IX_CartSessionData_ID", newName: "IX_Cart_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_Cart_ID", newName: "IX_CartSessionData_ID");
            RenameColumn(table: "dbo.Products", name: "Cart_ID", newName: "CartSessionData_ID");
            RenameTable(name: "dbo.Carts", newName: "CartSessionDatas");
        }
    }
}
