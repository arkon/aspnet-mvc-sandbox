namespace TrackaryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class utorid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UTORid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "UTORid");
        }
    }
}
