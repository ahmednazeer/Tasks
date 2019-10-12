namespace HPS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Results", "PateintID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Results", "PateintID", c => c.Int(nullable: false));
        }
    }
}
