namespace SampleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teacher2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Gender", c => c.Boolean(nullable: false));
        }
    }
}
