namespace StudentRegistrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dummyAttributeDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Department", "dummy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Department", "dummy", c => c.Int(nullable: false));
        }
    }
}
