namespace HPS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Results", name: "Patient_Id", newName: "PatientID");
            RenameIndex(table: "dbo.Results", name: "IX_Patient_Id", newName: "IX_PatientID");
            DropColumn("dbo.Results", "PateintID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Results", "PateintID", c => c.String());
            RenameIndex(table: "dbo.Results", name: "IX_PatientID", newName: "IX_Patient_Id");
            RenameColumn(table: "dbo.Results", name: "PatientID", newName: "Patient_Id");
        }
    }
}
