namespace VidlyAU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentaltoDB3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Rentals", new[] { "customer_Id" });
            DropIndex("dbo.Rentals", new[] { "movies_Id" });
            CreateIndex("dbo.Rentals", "Customer_Id");
            CreateIndex("dbo.Rentals", "Movies_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Rentals", new[] { "Movies_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            CreateIndex("dbo.Rentals", "movies_Id");
            CreateIndex("dbo.Rentals", "customer_Id");
        }
    }
}
