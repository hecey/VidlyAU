namespace VidlyAU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixIdGenres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genres_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genres_Id" });
            DropColumn("dbo.Movies", "GenresId");
            RenameColumn(table: "dbo.Movies", name: "Genres_Id", newName: "GenresId");
            AlterColumn("dbo.Movies", "GenresId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "GenresId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GenresId");
            AddForeignKey("dbo.Movies", "GenresId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenresId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenresId" });
            AlterColumn("dbo.Movies", "GenresId", c => c.Byte());
            AlterColumn("dbo.Movies", "GenresId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Movies", name: "GenresId", newName: "Genres_Id");
            AddColumn("dbo.Movies", "GenresId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Genres_Id");
            AddForeignKey("dbo.Movies", "Genres_Id", "dbo.Genres", "Id");
        }
    }
}
