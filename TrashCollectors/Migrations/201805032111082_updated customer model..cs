namespace TrashCollectors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedcustomermodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "StreetAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "StreetAddress", c => c.String(nullable: false));
        }
    }
}