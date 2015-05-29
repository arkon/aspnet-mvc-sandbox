namespace TrackaryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calculaterewards : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Rewards", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transactions", "Rewards", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Rewards");
            DropColumn("dbo.Customers", "Rewards");
        }
    }
}
