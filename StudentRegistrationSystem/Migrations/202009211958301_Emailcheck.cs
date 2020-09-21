namespace StudentRegistrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Emailcheck : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lecturer", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lecturer", "Email", c => c.String());
        }
    }
}
