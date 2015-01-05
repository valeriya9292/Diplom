namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_nullable_from_avatar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrmUsers", "Avatar", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrmUsers", "Avatar");
        }
    }
}
