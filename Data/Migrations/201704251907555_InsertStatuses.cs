namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertStatuses : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO status(description) Values ('Not In Production')");
            Sql("Insert INTO status(description) Values ('In Kitting')");
            Sql("Insert INTO status(description) Values ('In Welding')");
            Sql("Insert INTO status(description) Values ('In Brazing')");
            Sql("Insert INTO status(description) Values ('In Molding')");
            Sql("Insert INTO status(description) Values ('Complete')");
        }
        
        public override void Down()
        {
        }
    }
}
