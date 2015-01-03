namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class birhthday_nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrmUsers", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrmUsers", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
