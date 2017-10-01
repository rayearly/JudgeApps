namespace JudgeApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMarkIdToOptionalInJunction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JudgeBoothMarks", "MarkId", "dbo.Marks");
            DropIndex("dbo.JudgeBoothMarks", new[] { "MarkId" });
            AlterColumn("dbo.JudgeBoothMarks", "MarkId", c => c.Int());
            CreateIndex("dbo.JudgeBoothMarks", "MarkId");
            AddForeignKey("dbo.JudgeBoothMarks", "MarkId", "dbo.Marks", "MarkId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JudgeBoothMarks", "MarkId", "dbo.Marks");
            DropIndex("dbo.JudgeBoothMarks", new[] { "MarkId" });
            AlterColumn("dbo.JudgeBoothMarks", "MarkId", c => c.Int(nullable: false));
            CreateIndex("dbo.JudgeBoothMarks", "MarkId");
            AddForeignKey("dbo.JudgeBoothMarks", "MarkId", "dbo.Marks", "MarkId", cascadeDelete: true);
        }
    }
}
