namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductionOrderHeader_LineClassesAndDBSets : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.prod_order_line", new[] { "status_id" });
            DropIndex("dbo.prod_order_line", new[] { "prod_order_number" });
            DropTable("dbo.prod_order_line");
            DropTable("dbo.prod_order_hdr");
        }
    }
}
