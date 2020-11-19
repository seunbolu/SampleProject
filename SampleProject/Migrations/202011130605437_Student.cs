namespace SampleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Gender", c => c.Boolean(nullable: false));
        }
    }
}
