namespace WHA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class justchecking : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hydrants", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Hydrants", "SupervisorName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hydrants", "SupervisorName", c => c.String());
            AlterColumn("dbo.Hydrants", "Location", c => c.String());
        }
    }
}
