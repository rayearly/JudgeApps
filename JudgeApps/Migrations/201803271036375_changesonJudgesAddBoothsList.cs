namespace JudgeApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesonJudgesAddBoothsList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Booths", "Judge_Id", c => c.Int());
            CreateIndex("dbo.Booths", "Judge_Id");
            AddForeignKey("dbo.Booths", "Judge_Id", "dbo.Judges", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Booths", "Judge_Id", "dbo.Judges");
            DropIndex("dbo.Booths", new[] { "Judge_Id" });
            DropColumn("dbo.Booths", "Judge_Id");
        }
    }
}
