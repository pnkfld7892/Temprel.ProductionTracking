namespace Temprel.ProductionTracking.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Data.Entities;

    public class TemprelEntities : DbContext
    {
        // Your context has been configured to use a 'TemprelEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Data.TemprelEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TemprelEntities' 
        // connection string in the application configuration file.
        public TemprelEntities()
            : base("name=TemprelEntities")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<oe_hdr> oe_hdr { get; set; }
        public DbSet<oe_line> oe_line { get; set; }
        public DbSet<status> status { get; set; }

        public DbSet<customer> customers { get; set; }

        public DbSet<prod_order_hdr> prod_order_hdr { get; set; }
        public DbSet<prod_order_line> prod_order_line { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}