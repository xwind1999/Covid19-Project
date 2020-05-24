namespace CovidAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountryStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CountryStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Slug = c.String(),
                        NewConfirmed = c.Int(nullable: false),
                        TotalConfirmed = c.Int(nullable: false),
                        NewDeaths = c.Int(nullable: false),
                        TotalDeaths = c.Int(nullable: false),
                        NewRecovered = c.Int(nullable: false),
                        TotalRecovered = c.Int(nullable: false),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CountryStatus");
        }
    }
}
