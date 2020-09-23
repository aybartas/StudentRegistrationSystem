namespace StudentRegistrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableLecID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "LecturerID", "dbo.Lecturer");
            DropIndex("dbo.User", new[] { "LecturerID" });
            AlterColumn("dbo.User", "LecturerID", c => c.Int());
            CreateIndex("dbo.User", "LecturerID");
            AddForeignKey("dbo.User", "LecturerID", "dbo.Lecturer", "LecturerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "LecturerID", "dbo.Lecturer");
            DropIndex("dbo.User", new[] { "LecturerID" });
            AlterColumn("dbo.User", "LecturerID", c => c.Int(nullable: false));
            CreateIndex("dbo.User", "LecturerID");
            AddForeignKey("dbo.User", "LecturerID", "dbo.Lecturer", "LecturerID", cascadeDelete: true);
        }
    }
}
