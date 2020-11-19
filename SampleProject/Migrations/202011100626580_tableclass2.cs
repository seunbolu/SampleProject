namespace SampleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableclass2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "detail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Classes", "detail");
        }
    }
}
