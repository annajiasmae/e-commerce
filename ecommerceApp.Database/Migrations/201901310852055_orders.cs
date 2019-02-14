namespace ecommerceApp.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.String(),
                        status = c.String(),
                        orderDate = c.DateTime(nullable: false),
                        totalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qte = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                        produit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Produits", t => t.produit_Id)
                .Index(t => t.OrderId)
                .Index(t => t.produit_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "produit_Id", "dbo.Produits");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "produit_Id" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
        }
    }
}
