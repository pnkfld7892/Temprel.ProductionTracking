namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatusTableAndFK_in_oe_line : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.status",
                c => new
                    {
                        status_id = c.Int(nullable: false, identity: true),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.status_id);
            
            AlterColumn("dbo.oe_line", "status_id", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.oe_line", "status_id", c => c.Int(nullable: false));
            DropTable("dbo.status");
        }
    }
}
