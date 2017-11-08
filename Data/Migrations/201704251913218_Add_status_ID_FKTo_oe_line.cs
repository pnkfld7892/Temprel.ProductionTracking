namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_status_ID_FKTo_oe_line : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.oe_line", "status_id");
            AddForeignKey("dbo.oe_line", "status_id", "dbo.status", "status_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.oe_line", "status_id", "dbo.status");
            DropIndex("dbo.oe_line", new[] { "status_id" });
        }
    }
}
