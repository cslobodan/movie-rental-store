namespace MoviesRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MoviesRented", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "MoviesReturned", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "MoviesReturned");
            DropColumn("dbo.Customers", "MoviesRented");
        }
    }
}
