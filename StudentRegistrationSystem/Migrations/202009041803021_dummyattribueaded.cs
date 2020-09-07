namespace StudentRegistrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dummyattribueaded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Department", "dummy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Department", "dummy");
        }
    }
}
