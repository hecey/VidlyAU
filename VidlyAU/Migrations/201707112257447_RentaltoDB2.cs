namespace VidlyAU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentaltoDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "customer_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "movies_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "customer_Id");
            CreateIndex("dbo.Rentals", "movies_Id");
            AddForeignKey("dbo.Rentals", "customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "movies_Id", "dbo.Movies", "Id", cascadeDelete: true);
            DropColumn("dbo.Rentals", "CustomerId");
            DropColumn("dbo.Rentals", "MoviesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "MoviesId", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rentals", "movies_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "movies_Id" });
            DropIndex("dbo.Rentals", new[] { "customer_Id" });
            DropColumn("dbo.Rentals", "movies_Id");
            DropColumn("dbo.Rentals", "customer_Id");
        }
    }
}
