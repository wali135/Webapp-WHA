namespace WHA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DriverCNiCandPHone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "CNIC", c => c.String(nullable: false));
            AddColumn("dbo.Drivers", "MobileNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "MobileNumber");
            DropColumn("dbo.Drivers", "CNIC");
        }
    }
}
