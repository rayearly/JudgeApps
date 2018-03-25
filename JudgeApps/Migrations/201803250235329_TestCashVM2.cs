namespace JudgeApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestCashVM2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CashRecipientVms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Recipient = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CashRecipientVms");
        }
    }
}
