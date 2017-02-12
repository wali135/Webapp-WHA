namespace WHA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rfidadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "Uid", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "Uid");
        }
    }
}
