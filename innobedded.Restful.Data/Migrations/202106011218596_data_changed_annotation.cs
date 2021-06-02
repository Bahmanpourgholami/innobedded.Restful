namespace innobedded.Restful.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data_changed_annotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
        }
    }
}
