namespace Ecart.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConfigTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configs",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 255),
                        Value = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Key);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Configs");
        }
    }
}
