namespace TrackaryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TCardString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "TCardBarcode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "TCardBarcode", c => c.Int(nullable: false));
        }
    }
}
