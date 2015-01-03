namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrmComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        UserId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrmTasks", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.OrmUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.OrmTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatorId = c.Int(nullable: false),
                        Description = c.String(),
                        Duration = c.DateTime(nullable: false),
                        Name = c.String(),
                        Progress = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProjectId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrmProjects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.OrmUsers", t => t.User_Id)
                .Index(t => t.ProjectId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.OrmProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Duration = c.DateTime(nullable: false),
                        Name = c.String(),
                        Progress = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrmUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Avatar = c.Binary(),
                        Birthday = c.DateTime(nullable: false),
                        Phone = c.String(),
                        Skype = c.String(),
                        Email = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrmProjectMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrmProjects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.OrmUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.OrmTaskAssignees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrmTasks", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.OrmUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TaskId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrmTimeLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        UserId = c.Int(nullable: false),
                        Week = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        HoursInMonday = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HoursInTuesday = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HoursInWednesday = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HoursInThursday = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HoursInFriday = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HoursInSaturday = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HoursInSunday = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrmUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrmTimeLogs", "UserId", "dbo.OrmUsers");
            DropForeignKey("dbo.OrmTaskAssignees", "UserId", "dbo.OrmUsers");
            DropForeignKey("dbo.OrmTaskAssignees", "TaskId", "dbo.OrmTasks");
            DropForeignKey("dbo.OrmProjectMembers", "UserId", "dbo.OrmUsers");
            DropForeignKey("dbo.OrmProjectMembers", "ProjectId", "dbo.OrmProjects");
            DropForeignKey("dbo.OrmComments", "UserId", "dbo.OrmUsers");
            DropForeignKey("dbo.OrmComments", "TaskId", "dbo.OrmTasks");
            DropForeignKey("dbo.OrmTasks", "User_Id", "dbo.OrmUsers");
            DropForeignKey("dbo.OrmTasks", "ProjectId", "dbo.OrmProjects");
            DropIndex("dbo.OrmTimeLogs", new[] { "UserId" });
            DropIndex("dbo.OrmTaskAssignees", new[] { "UserId" });
            DropIndex("dbo.OrmTaskAssignees", new[] { "TaskId" });
            DropIndex("dbo.OrmProjectMembers", new[] { "ProjectId" });
            DropIndex("dbo.OrmProjectMembers", new[] { "UserId" });
            DropIndex("dbo.OrmTasks", new[] { "User_Id" });
            DropIndex("dbo.OrmTasks", new[] { "ProjectId" });
            DropIndex("dbo.OrmComments", new[] { "TaskId" });
            DropIndex("dbo.OrmComments", new[] { "UserId" });
            DropTable("dbo.OrmTimeLogs");
            DropTable("dbo.OrmTaskAssignees");
            DropTable("dbo.OrmProjectMembers");
            DropTable("dbo.OrmUsers");
            DropTable("dbo.OrmProjects");
            DropTable("dbo.OrmTasks");
            DropTable("dbo.OrmComments");
        }
    }
}
