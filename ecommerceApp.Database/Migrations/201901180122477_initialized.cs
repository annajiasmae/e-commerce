namespace ecommerceApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialized : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        nom = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        prix = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nom = c.String(),
                        description = c.String(),
                        categorie_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.categorie_Id)
                .Index(t => t.categorie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produits", "categorie_Id", "dbo.Categories");
            DropIndex("dbo.Produits", new[] { "categorie_Id" });
            DropTable("dbo.Produits");
            DropTable("dbo.Categories");
        }
    }
}
