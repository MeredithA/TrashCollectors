namespace TrashCollectors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suspedservices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SuspendServices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        SuspensionDuration = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SuspendServices", "CustomerId", "dbo.Customers");
            DropIndex("dbo.SuspendServices", new[] { "CustomerId" });
            DropTable("dbo.SuspendServices");
        }
    }
}
