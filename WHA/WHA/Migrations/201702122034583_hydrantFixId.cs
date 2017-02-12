namespace WHA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hydrantFixId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entries", "Hydrant_Id", "dbo.Hydrants");
            DropIndex("dbo.Entries", new[] { "Hydrant_Id" });
            AddColumn("dbo.Entries", "HydrantId", c => c.Int(nullable: false));
            DropColumn("dbo.Entries", "Hydrant_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entries", "Hydrant_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Entries", "HydrantId");
            CreateIndex("dbo.Entries", "Hydrant_Id");
            AddForeignKey("dbo.Entries", "Hydrant_Id", "dbo.Hydrants", "Id", cascadeDelete: true);
        }
    }
}
