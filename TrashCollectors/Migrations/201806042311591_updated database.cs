namespace TrashCollectors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SuspendServices", "StartDate", c => c.DateTime());
            AlterColumn("dbo.SuspendServices", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SuspendServices", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SuspendServices", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
