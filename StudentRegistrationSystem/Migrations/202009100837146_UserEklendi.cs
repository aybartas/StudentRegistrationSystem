namespace StudentRegistrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserEklendi : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Student", newName: "User");
            DropForeignKey("dbo.Enrollment", "StudentID", "dbo.Student");
            RenameColumn(table: "dbo.Enrollment", name: "StudentID", newName: "UserID");
            RenameIndex(table: "dbo.Enrollment", name: "IX_StudentID", newName: "IX_UserID");
            DropPrimaryKey("dbo.User");
            AddColumn("dbo.User", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.User", "Role", c => c.String());
            AddPrimaryKey("dbo.User", "UserID");
            AddForeignKey("dbo.Enrollment", "UserID", "dbo.User", "UserID");
            DropColumn("dbo.User", "StudentID");
            DropTable("dbo.Admin");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
            AddColumn("dbo.User", "StudentID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Enrollment", "UserID", "dbo.User");
            DropPrimaryKey("dbo.User");
            DropColumn("dbo.User", "Role");
            DropColumn("dbo.User", "UserID");
            AddPrimaryKey("dbo.User", "StudentID");
            RenameIndex(table: "dbo.Enrollment", name: "IX_UserID", newName: "IX_StudentID");
            RenameColumn(table: "dbo.Enrollment", name: "UserID", newName: "StudentID");
            AddForeignKey("dbo.Enrollment", "StudentID", "dbo.Student", "StudentID");
            RenameTable(name: "dbo.User", newName: "Student");
        }
    }
}
