namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makefieldsnullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrmComments", "CreationDate", c => c.DateTime());
            AlterColumn("dbo.OrmTasks", "Duration", c => c.DateTime());
            AlterColumn("dbo.OrmTasks", "StartDate", c => c.DateTime());
            AlterColumn("dbo.OrmProjects", "Duration", c => c.DateTime());
            AlterColumn("dbo.OrmProjects", "StartDate", c => c.DateTime());
            AlterColumn("dbo.OrmUsers", "CreationDate", c => c.DateTime());
            DropColumn("dbo.OrmUsers", "Avatar");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrmUsers", "Avatar", c => c.Binary());
            AlterColumn("dbo.OrmUsers", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrmProjects", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrmProjects", "Duration", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrmTasks", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrmTasks", "Duration", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OrmComments", "CreationDate", c => c.DateTime(nullable: false));
        }
    }
}
