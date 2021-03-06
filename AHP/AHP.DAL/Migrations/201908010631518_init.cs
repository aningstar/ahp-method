namespace AHP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlternativeRanks",
                c => new
                    {
                        AlternativeRankId = c.Guid(nullable: false),
                        Alternative1 = c.Int(nullable: false),
                        Alternative2 = c.Int(nullable: false),
                        Preference = c.Double(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        CriteriaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AlternativeRankId)
                .ForeignKey("dbo.Criteria", t => t.CriteriaId, cascadeDelete: true)
                .Index(t => t.CriteriaId);
            
            CreateTable(
                "dbo.Criteria",
                c => new
                    {
                        CriteriaId = c.Guid(nullable: false),
                        Order = c.Int(nullable: false),
                        CriteriaName = c.String(),
                        Priority = c.Double(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CriteriaId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.CriteriaRanks",
                c => new
                    {
                        CriteriaRankId = c.Guid(nullable: false),
                        Column = c.Int(nullable: false),
                        Priority = c.Double(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        CriteriaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CriteriaRankId)
                .ForeignKey("dbo.Criteria", t => t.CriteriaId, cascadeDelete: true)
                .Index(t => t.CriteriaId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Guid(nullable: false),
                        Username = c.String(nullable: false, maxLength: 50),
                        ProjectName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Alternatives",
                c => new
                    {
                        AlternativeId = c.Guid(nullable: false),
                        Order = c.Int(nullable: false),
                        AlternativeName = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        FinalPriority = c.Double(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AlternativeId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Criteria", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Alternatives", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.CriteriaRanks", "CriteriaId", "dbo.Criteria");
            DropForeignKey("dbo.AlternativeRanks", "CriteriaId", "dbo.Criteria");
            DropIndex("dbo.Alternatives", new[] { "ProjectId" });
            DropIndex("dbo.CriteriaRanks", new[] { "CriteriaId" });
            DropIndex("dbo.Criteria", new[] { "ProjectId" });
            DropIndex("dbo.AlternativeRanks", new[] { "CriteriaId" });
            DropTable("dbo.Alternatives");
            DropTable("dbo.Projects");
            DropTable("dbo.CriteriaRanks");
            DropTable("dbo.Criteria");
            DropTable("dbo.AlternativeRanks");
        }
    }
}
