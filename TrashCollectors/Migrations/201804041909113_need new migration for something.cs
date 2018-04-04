namespace TrashCollectors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class neednewmigrationforsomething : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "StreetAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "ScheduledPickUpDay", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "StreetAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "State", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "State", c => c.String());
            AlterColumn("dbo.Employees", "City", c => c.String());
            AlterColumn("dbo.Employees", "StreetAddress", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "ScheduledPickUpDay", c => c.String());
            AlterColumn("dbo.Customers", "State", c => c.String());
            AlterColumn("dbo.Customers", "City", c => c.String());
            AlterColumn("dbo.Customers", "StreetAddress", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
        }
    }
}
