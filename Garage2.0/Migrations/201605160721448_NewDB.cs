namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "CheckInTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "CheckInTime", c => c.String());
        }
    }
}
