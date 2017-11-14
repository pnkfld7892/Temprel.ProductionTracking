namespace Temprel.ProductionTracking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newinit : DbMigration
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
                        promised_date = c.DateTime(),
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
                        status_id = c.Int(),
                    })
                .PrimaryKey(t => new { t.order_no, t.line_no })
                .ForeignKey("dbo.oe_hdr", t => t.order_no, cascadeDelete: true)
                .ForeignKey("dbo.status", t => t.status_id)
                .Index(t => t.order_no)
                .Index(t => t.status_id);
            
            CreateTable(
                "dbo.status",
                c => new
                    {
                        status_id = c.Int(nullable: false, identity: true),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.status_id);
            
            CreateTable(
                "dbo.prod_order_hdr",
                c => new
                    {
                        prod_order_number = c.Decimal(nullable: false, precision: 18, scale: 2),
                        order_date = c.DateTime(nullable: false),
                        required_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.prod_order_number);
            
            CreateTable(
                "dbo.prod_order_line",
                c => new
                    {
                        prod_order_number = c.Decimal(nullable: false, precision: 18, scale: 2),
                        line_number = c.Decimal(nullable: false, precision: 18, scale: 2),
                        item_id = c.String(),
                        qty_to_make = c.Decimal(nullable: false, precision: 18, scale: 2),
                        status_id = c.Int(),
                    })
                .PrimaryKey(t => new { t.prod_order_number, t.line_number })
                .ForeignKey("dbo.status", t => t.status_id)
                .ForeignKey("dbo.prod_order_hdr", t => t.prod_order_number, cascadeDelete: true)
                .Index(t => t.prod_order_number)
                .Index(t => t.status_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.prod_order_line", "prod_order_number", "dbo.prod_order_hdr");
            DropForeignKey("dbo.prod_order_line", "status_id", "dbo.status");
            DropForeignKey("dbo.oe_line", "status_id", "dbo.status");
            DropForeignKey("dbo.oe_line", "order_no", "dbo.oe_hdr");
            DropForeignKey("dbo.oe_hdr", "customer_id", "dbo.customers");
            DropIndex("dbo.prod_order_line", new[] { "status_id" });
            DropIndex("dbo.prod_order_line", new[] { "prod_order_number" });
            DropIndex("dbo.oe_line", new[] { "status_id" });
            DropIndex("dbo.oe_line", new[] { "order_no" });
            DropIndex("dbo.oe_hdr", new[] { "customer_id" });
            DropTable("dbo.prod_order_line");
            DropTable("dbo.prod_order_hdr");
            DropTable("dbo.status");
            DropTable("dbo.oe_line");
            DropTable("dbo.oe_hdr");
            DropTable("dbo.customers");
        }
    }
}
