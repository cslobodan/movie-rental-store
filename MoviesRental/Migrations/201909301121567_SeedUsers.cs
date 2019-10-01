namespace MoviesRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Hometown], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName]) VALUES (N'a1282797-35f9-4b54-8eb0-e99f21366bfd', N'Novi Sad', N'guest@mp4u.com', 0, N'AE3b1q04xQkQnlkmXQOOX07l/W8kC7dcnr6nVMxp7qWa30EPppcLj9MaGY2mKNCp0Q==', N'e0f56759-444a-46d9-8f59-a399bfbe8bac', NULL, 0, 0, NULL, 1, 0, N'guest@mp4u.com', N'Guest', N'User')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Hometown], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName]) VALUES (N'd156b43e-4942-4cd2-be4a-df2f8ec4940b', N'Novi Sad', N'admin@mp4u.com', 0, N'ACaTLCnBp+UmLI5azrY/wY155cVLQ2v9btL1E7F1R3Rk5WATVTARLi6PbeIlg3CuyQ==', N'6e0de93b-ff1a-407a-8398-02ac4fa94f57', NULL, 0, 0, NULL, 1, 0, N'admin@mp4u.com', N'Admin', N'User')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'143c9ff4-c00c-4b14-b428-93bf15880507', N'Can Manage Movies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd156b43e-4942-4cd2-be4a-df2f8ec4940b', N'143c9ff4-c00c-4b14-b428-93bf15880507')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
