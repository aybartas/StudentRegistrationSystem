namespace StudentRegistrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeysAddedAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Section", "LecturerID", "dbo.Lecturer");
            DropForeignKey("dbo.Enrollment", "SectionID", "dbo.Section");
            DropForeignKey("dbo.Section", "LectureID", "dbo.Lecture");
            DropForeignKey("dbo.Student", "LecturerID", "dbo.Lecturer");
            DropIndex("dbo.Enrollment", new[] { "Student_StudentID" });
            RenameColumn(table: "dbo.Enrollment", name: "Student_StudentID", newName: "StudentID");
            AlterColumn("dbo.Enrollment", "StudentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Enrollment", "StudentID");
            AddForeignKey("dbo.Section", "LecturerID", "dbo.Lecturer", "LecturerID");
            AddForeignKey("dbo.Enrollment", "SectionID", "dbo.Section", "SectionID");
            AddForeignKey("dbo.Section", "LectureID", "dbo.Lecture", "LectureID");
            AddForeignKey("dbo.Student", "LecturerID", "dbo.Lecturer", "LecturerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "LecturerID", "dbo.Lecturer");
            DropForeignKey("dbo.Section", "LectureID", "dbo.Lecture");
            DropForeignKey("dbo.Enrollment", "SectionID", "dbo.Section");
            DropForeignKey("dbo.Section", "LecturerID", "dbo.Lecturer");
            DropIndex("dbo.Enrollment", new[] { "StudentID" });
            AlterColumn("dbo.Enrollment", "StudentID", c => c.Int());
            RenameColumn(table: "dbo.Enrollment", name: "StudentID", newName: "Student_StudentID");
            CreateIndex("dbo.Enrollment", "Student_StudentID");
            AddForeignKey("dbo.Student", "LecturerID", "dbo.Lecturer", "LecturerID", cascadeDelete: true);
            AddForeignKey("dbo.Section", "LectureID", "dbo.Lecture", "LectureID", cascadeDelete: true);
            AddForeignKey("dbo.Enrollment", "SectionID", "dbo.Section", "SectionID", cascadeDelete: true);
            AddForeignKey("dbo.Section", "LecturerID", "dbo.Lecturer", "LecturerID", cascadeDelete: true);
        }
    }
}
