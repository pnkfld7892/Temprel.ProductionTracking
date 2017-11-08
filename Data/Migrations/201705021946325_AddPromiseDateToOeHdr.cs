namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPromiseDateToOeHdr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.oe_hdr", "promised_date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.oe_hdr", "promised_date");
        }
    }
}
