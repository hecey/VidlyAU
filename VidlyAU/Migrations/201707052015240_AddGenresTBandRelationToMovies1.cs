namespace VidlyAU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenresTBandRelationToMovies1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenresId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenresId" });
            DropPrimaryKey("dbo.Genres");
            AddColumn("dbo.Movies", "Genres_Id", c => c.Byte());
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Movies", "Genres_Id");
            AddForeignKey("dbo.Movies", "Genres_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genres_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genres_Id" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Movies", "Genres_Id");
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Movies", "GenresId");
            AddForeignKey("dbo.Movies", "GenresId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
