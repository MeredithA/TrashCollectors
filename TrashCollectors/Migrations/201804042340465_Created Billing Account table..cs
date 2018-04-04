namespace TrashCollectors.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedBillingAccounttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BilingAccounts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Balance = c.Double(nullable: false),
                        LastChargeDate = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BilingAccounts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.BilingAccounts", new[] { "CustomerId" });
            DropTable("dbo.BilingAccounts");
        }
    }
}
