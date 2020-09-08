namespace StudentRegistrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iamdonewiththis : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollment", "StudentID", "dbo.Student");
            DropPrimaryKey("dbo.Student");
            AlterColumn("dbo.Student", "StudentID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Student", "StudentID");
            AddForeignKey("dbo.Enrollment", "StudentID", "dbo.Student", "StudentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "StudentID", "dbo.Student");
            DropPrimaryKey("dbo.Student");
            AlterColumn("dbo.Student", "StudentID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Student", "StudentID");
            AddForeignKey("dbo.Enrollment", "StudentID", "dbo.Student", "StudentID");
        }
    }
}
