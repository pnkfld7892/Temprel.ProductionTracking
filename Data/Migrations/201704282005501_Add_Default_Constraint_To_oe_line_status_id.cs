namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Default_Constraint_To_oe_line_status_id : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE oe_line ADD CONSTRAINT status_default DEFAULT 1 for status_id");
        }
        
        public override void Down()
        {
        }
    }
}
