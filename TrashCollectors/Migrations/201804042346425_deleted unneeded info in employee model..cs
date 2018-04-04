namespace TrashCollectors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedunneededinfoinemployeemodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "StreetAddress");
            DropColumn("dbo.Employees", "City");
            DropColumn("dbo.Employees", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "State", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "City", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "StreetAddress", c => c.String(nullable: false));
        }
    }
}
