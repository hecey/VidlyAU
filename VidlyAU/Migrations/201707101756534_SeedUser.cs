namespace VidlyAU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f893f1f5-4b5e-4764-ac85-0fd101a587f2', N'admin@vidly.com', 0, N'AL5y20D2pXHoZ4zyZN79jnUsU5SETeSliICqBI0s10YNuT239n9RofliQMBkH7lOAg==', N'06a59256-142d-469e-8223-3811e108746d', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f92fcfea-460b-4032-81a9-ebd824a1181f', N'guest@vidly.com', 0, N'AKPWgrI9HpTEj+vfbzLPwkR3gmq6clW6UjRVGtQ9tnIVDkxp0y9pJwdSaRkUWFBgJg==', N'72d1e13e-dc66-4a8c-bfcb-b58aeb604e1b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bde62247-68f9-4f66-ae8c-f91672ceed9a', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f893f1f5-4b5e-4764-ac85-0fd101a587f2', N'bde62247-68f9-4f66-ae8c-f91672ceed9a')

    ");
        }
        
        public override void Down()
        {
        }
    }
}
