namespace JudgeApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Booths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BoothId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParticipantId = c.String(),
                        BoothId = c.Int(nullable: false),
                        MarkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Booths", t => t.BoothId)
                .Index(t => t.BoothId);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        MarkId = c.Int(nullable: false, identity: true),
                        ANovelty = c.Int(nullable: false),
                        ACreativity = c.Int(nullable: false),
                        AReflects = c.Int(nullable: false),
                        BOptimal = c.Int(nullable: false),
                        BContribution = c.Int(nullable: false),
                        CPosterOral = c.Int(nullable: false),
                        CDesignDisplay = c.Int(nullable: false),
                        DTargetMarket = c.Int(nullable: false),
                        DCompetitiveness = c.Int(nullable: false),
                        TotalMarks = c.Double(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MarkId)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.JudgeBoothMarks",
                c => new
                    {
                        JudgeId = c.Int(nullable: false),
                        BoothId = c.Int(nullable: false),
                        MarkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JudgeId, t.BoothId })
                .ForeignKey("dbo.Booths", t => t.BoothId, cascadeDelete: true)
                .ForeignKey("dbo.Judges", t => t.JudgeId, cascadeDelete: true)
                .ForeignKey("dbo.Marks", t => t.MarkId, cascadeDelete: true)
                .Index(t => t.JudgeId)
                .Index(t => t.BoothId)
                .Index(t => t.MarkId);
            
            CreateTable(
                "dbo.Judges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        Affiliation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Affiliation = c.String(),
                        Email = c.String(),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Participants", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Marks", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.JudgeBoothMarks", "MarkId", "dbo.Marks");
            DropForeignKey("dbo.JudgeBoothMarks", "JudgeId", "dbo.Judges");
            DropForeignKey("dbo.JudgeBoothMarks", "BoothId", "dbo.Booths");
            DropForeignKey("dbo.Groups", "BoothId", "dbo.Booths");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Participants", new[] { "GroupId" });
            DropIndex("dbo.JudgeBoothMarks", new[] { "MarkId" });
            DropIndex("dbo.JudgeBoothMarks", new[] { "BoothId" });
            DropIndex("dbo.JudgeBoothMarks", new[] { "JudgeId" });
            DropIndex("dbo.Marks", new[] { "GroupId" });
            DropIndex("dbo.Groups", new[] { "BoothId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Participants");
            DropTable("dbo.Judges");
            DropTable("dbo.JudgeBoothMarks");
            DropTable("dbo.Marks");
            DropTable("dbo.Groups");
            DropTable("dbo.Booths");
        }
    }
}
