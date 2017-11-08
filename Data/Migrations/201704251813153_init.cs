namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.customers",
                c => new
                    {
                        customer_id = c.Decimal(nullable: false, precision: 18, scale: 2),
                        customer_name = c.String(),
                    })
                .PrimaryKey(t => t.customer_id);
            
            CreateTable(
                "dbo.oe_hdr",
                c => new
                    {
                        order_no = c.String(nullable: false, maxLength: 8),
                        customer_id = c.Decimal(nullable: false, precision: 18, scale: 2),
                        completed = c.String(),
                        order_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.order_no)
                .ForeignKey("dbo.customers", t => t.customer_id, cascadeDelete: true)
                .Index(t => t.customer_id);
            
            CreateTable(
                "dbo.oe_line",
                c => new
                    {
                        order_no = c.String(nullable: false, maxLength: 8),
                        line_no = c.Decimal(nullable: false, precision: 18, scale: 2),
                        item_id = c.String(),
                        status_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.order_no, t.line_no })
                .ForeignKey("dbo.oe_hdr", t => t.order_no, cascadeDelete: true)
                .Index(t => t.order_no);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.oe_line", "order_no", "dbo.oe_hdr");
            DropForeignKey("dbo.oe_hdr", "customer_id", "dbo.customers");
            DropIndex("dbo.oe_line", new[] { "order_no" });
            DropIndex("dbo.oe_hdr", new[] { "customer_id" });
            DropTable("dbo.oe_line");
            DropTable("dbo.oe_hdr");
            DropTable("dbo.customers");
        }
    }
}
