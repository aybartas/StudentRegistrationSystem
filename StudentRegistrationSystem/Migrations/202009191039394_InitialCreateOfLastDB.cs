namespace StudentRegistrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateOfLastDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentCode = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentCode);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        Grade = c.String(),
                        UserID = c.Int(nullable: false),
                        SectionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Section", t => t.SectionID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.SectionID);
            
            CreateTable(
                "dbo.Section",
                c => new
                    {
                        SectionID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Time = c.String(),
                        EndTime = c.String(),
                        Day = c.String(),
                        Quota = c.Int(nullable: false),
                        Building = c.String(),
                        Classroom = c.String(),
                        LecturerID = c.Int(nullable: false),
                        LectureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SectionID)
                .ForeignKey("dbo.Lecture", t => t.LectureID, cascadeDelete: true)
                .ForeignKey("dbo.Lecturer", t => t.LecturerID, cascadeDelete: true)
                .Index(t => t.LecturerID)
                .Index(t => t.LectureID);
            
            CreateTable(
                "dbo.Lecture",
                c => new
                    {
                        LectureID = c.Int(nullable: false, identity: true),
                        LectureCode = c.String(),
                        Name = c.String(),
                        EducationType = c.String(),
                        Credit = c.Int(nullable: false),
                        Term = c.String(),
                        DepartmentCode = c.String(nullable:true,maxLength: 128),
                    })
                .PrimaryKey(t => t.LectureID)
                .ForeignKey("dbo.Department", t => t.DepartmentCode)
                .Index(t => t.DepartmentCode);
            
            CreateTable(
                "dbo.Lecturer",
                c => new
                    {
                        LecturerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        DepartmentCode = c.String(nullable:true,maxLength: 128),
                    })
                .PrimaryKey(t => t.LecturerID)
                .ForeignKey("dbo.Department", t => t.DepartmentCode)
                .Index(t => t.DepartmentCode);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        Name = c.String(),
                        LastName = c.String(),
                        CitizenshipNo = c.Long(nullable: false),
                        Gender = c.String(),
                        Phone = c.String(),
                        EducationType = c.String(),
                        Password = c.String(nullable: false, maxLength: 50),
                        Role = c.String(),
                        LecturerID = c.Int(nullable: true),
                        DepartmentCode = c.String(nullable:true,maxLength: 128),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Department", t => t.DepartmentCode)
                .ForeignKey("dbo.Lecturer", t => t.LecturerID, cascadeDelete: false)
                .Index(t => t.LecturerID)
                .Index(t => t.DepartmentCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "LecturerID", "dbo.Lecturer");
            DropForeignKey("dbo.Enrollment", "UserID", "dbo.User");
            DropForeignKey("dbo.User", "DepartmentCode", "dbo.Department");
            DropForeignKey("dbo.Section", "LecturerID", "dbo.Lecturer");
            DropForeignKey("dbo.Lecturer", "DepartmentCode", "dbo.Department");
            DropForeignKey("dbo.Section", "LectureID", "dbo.Lecture");
            DropForeignKey("dbo.Lecture", "DepartmentCode", "dbo.Department");
            DropForeignKey("dbo.Enrollment", "SectionID", "dbo.Section");
            DropIndex("dbo.User", new[] { "DepartmentCode" });
            DropIndex("dbo.User", new[] { "LecturerID" });
            DropIndex("dbo.Lecturer", new[] { "DepartmentCode" });
            DropIndex("dbo.Lecture", new[] { "DepartmentCode" });
            DropIndex("dbo.Section", new[] { "LectureID" });
            DropIndex("dbo.Section", new[] { "LecturerID" });
            DropIndex("dbo.Enrollment", new[] { "SectionID" });
            DropIndex("dbo.Enrollment", new[] { "UserID" });
            DropTable("dbo.User");
            DropTable("dbo.Lecturer");
            DropTable("dbo.Lecture");
            DropTable("dbo.Section");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Department");
        }
    }
}
