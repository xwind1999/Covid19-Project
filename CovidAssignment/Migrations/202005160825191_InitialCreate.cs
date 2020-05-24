namespace CovidAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Globals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewConfirmed = c.Int(nullable: false),
                        TotalConfirmed = c.Int(nullable: false),
                        NewDeaths = c.Int(nullable: false),
                        TotalDeaths = c.Int(nullable: false),
                        NewRecovered = c.Int(nullable: false),
                        TotalRecovered = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Globals");
        }
    }
}
