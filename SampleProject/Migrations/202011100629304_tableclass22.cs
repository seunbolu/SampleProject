namespace SampleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableclass22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "ClassName", c => c.String());
            DropColumn("dbo.Classes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classes", "Name", c => c.String());
            DropColumn("dbo.Classes", "ClassName");
        }
    }
}
