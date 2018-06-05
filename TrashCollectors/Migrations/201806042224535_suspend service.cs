namespace TrashCollectors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suspendservice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SuspensionDuration", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "SuspensionDuration");
        }
    }
}
