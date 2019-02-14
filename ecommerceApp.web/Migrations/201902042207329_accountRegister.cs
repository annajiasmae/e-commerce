namespace ecommerceApp.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accountRegister : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Adresse", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Adresse");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
