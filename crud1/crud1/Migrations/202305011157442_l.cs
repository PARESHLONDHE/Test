namespace crud1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class l : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        Catgory_Id = c.Int(nullable: false, identity: true),
                        CatgoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Catgory_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Catgory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Catagories", t => t.Catgory_Id, cascadeDelete: true)
                .Index(t => t.Catgory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Catgory_Id", "dbo.Catagories");
            DropIndex("dbo.Products", new[] { "Catgory_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Catagories");
        }
    }
}
