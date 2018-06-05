namespace TrashCollectors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suspendservices : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Services", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Services", new[] { "CustomerId" });
            AddColumn("dbo.SuspendServices", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SuspendServices", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.SuspendServices", "SuspensionDuration");
            DropTable("dbo.Services");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        PickUpDate = c.String(),
                        SuspensionDuration = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.SuspendServices", "SuspensionDuration", c => c.String());
            DropColumn("dbo.SuspendServices", "EndDate");
            DropColumn("dbo.SuspendServices", "StartDate");
            CreateIndex("dbo.Services", "CustomerId");
            AddForeignKey("dbo.Services", "CustomerId", "dbo.Customers", "ID", cascadeDelete: true);
        }
    }
}
