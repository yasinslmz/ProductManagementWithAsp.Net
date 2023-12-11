namespace ProductManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDb : DbMigration
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
                        Image = c.String(),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stock = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Number = c.Int(nullable: false),
                        IsButton = c.Boolean(nullable: false),
                        ButtonText = c.String(),
                        ButtonClasses = c.String(),
                        Title = c.String(),
                        TitleClasses = c.String(),
                        ContentText = c.String(),
                        ContentTextClasses = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Sliders");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
