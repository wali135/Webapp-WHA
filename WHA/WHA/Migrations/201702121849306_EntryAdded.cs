namespace WHA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntryAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Consumption = c.Single(nullable: false),
                        Driver_Id = c.Int(nullable: false),
                        Hydrant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.Driver_Id, cascadeDelete: true)
                .ForeignKey("dbo.Hydrants", t => t.Hydrant_Id, cascadeDelete: true)
                .Index(t => t.Driver_Id)
                .Index(t => t.Hydrant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entries", "Hydrant_Id", "dbo.Hydrants");
            DropForeignKey("dbo.Entries", "Driver_Id", "dbo.Drivers");
            DropIndex("dbo.Entries", new[] { "Hydrant_Id" });
            DropIndex("dbo.Entries", new[] { "Driver_Id" });
            DropTable("dbo.Entries");
        }
    }
}
