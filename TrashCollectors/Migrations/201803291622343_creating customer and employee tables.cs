namespace TrashCollectors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatingcustomerandemployeetables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "StreetAddress", c => c.String());
            DropColumn("dbo.Employees", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Address", c => c.String());
            DropColumn("dbo.Employees", "StreetAddress");
        }
    }
}
