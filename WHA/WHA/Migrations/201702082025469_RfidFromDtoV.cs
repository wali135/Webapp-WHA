namespace WHA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RfidFromDtoV : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "RfId", c => c.Int(nullable: false));
            DropColumn("dbo.Drivers", "RfId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "RfId", c => c.Int(nullable: false));
            DropColumn("dbo.Vehicles", "RfId");
        }
    }
}
