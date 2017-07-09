namespace VidlyAU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("insert into Genres (Id, Name) values (1,'Comedy');");
            Sql("insert into Genres (Id, Name) values (2,'Action');");
            Sql("insert into Genres (Id, Name) values (3,'Family');");
            Sql("insert into Genres (Id, Name) values (4,'Romance');");
            Sql("insert into Genres (Id, Name) values (5,'Thriller');");
        }
        
        public override void Down()
        {
        }
    }
}
