namespace StudentRegistrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userPropertiesFixed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String());
        }
    }
}
