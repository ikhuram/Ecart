namespace Ecart.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.String(),
                        CreatedOn = c.String(),
                        ProductCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ProductCategory_Id)
                .Index(t => t.ProductCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductCategory_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "ProductCategory_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
