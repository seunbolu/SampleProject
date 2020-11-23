namespace SampleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCityToStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Class", c => c.String());
            AddColumn("dbo.Students", "Session", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Session");
            DropColumn("dbo.Students", "Class");
        }
    }
}
