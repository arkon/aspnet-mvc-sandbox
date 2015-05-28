namespace TrackaryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalCost : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carts", "TotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carts", "TotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
