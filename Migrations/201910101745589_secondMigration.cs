namespace HPS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "Description", c => c.String());
            AddColumn("dbo.Results", "DoctorSignature", c => c.String());
            DropColumn("dbo.Results", "Desccription");
            DropColumn("dbo.Results", "Doctor");
            DropColumn("dbo.Results", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Results", "MyProperty", c => c.DateTime(nullable: false));
            AddColumn("dbo.Results", "Doctor", c => c.Int(nullable: false));
            AddColumn("dbo.Results", "Desccription", c => c.String());
            DropColumn("dbo.Results", "DoctorSignature");
            DropColumn("dbo.Results", "Description");
        }
    }
}
