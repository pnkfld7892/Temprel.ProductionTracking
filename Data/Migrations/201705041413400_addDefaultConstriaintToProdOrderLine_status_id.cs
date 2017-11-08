namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDefaultConstriaintToProdOrderLine_status_id : DbMigration
    {
        public override void Up()
        {
            Sql(@"Alter Table prod_order_line
                    ADD CONSTRAINT defaultStatusID
                    DEFAULT 1 FOR status_id
                    GO");
        }
        
        public override void Down()
        {
        }
    }
}
