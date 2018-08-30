namespace Database_Week1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Homelands : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Organizations", "Homeland_CountryID", "dbo.Countries");
            DropIndex("dbo.Organizations", new[] { "Homeland_CountryID" });
            CreateTable(
                "dbo.OrganizationCountries",
                c => new
                    {
                        Organization_OrganizationID = c.Int(nullable: false),
                        Country_CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Organization_OrganizationID, t.Country_CountryID })
                .ForeignKey("dbo.Organizations", t => t.Organization_OrganizationID, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.Country_CountryID, cascadeDelete: true)
                .Index(t => t.Organization_OrganizationID)
                .Index(t => t.Country_CountryID);
            
            DropColumn("dbo.Organizations", "Homeland_CountryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organizations", "Homeland_CountryID", c => c.Int());
            DropForeignKey("dbo.OrganizationCountries", "Country_CountryID", "dbo.Countries");
            DropForeignKey("dbo.OrganizationCountries", "Organization_OrganizationID", "dbo.Organizations");
            DropIndex("dbo.OrganizationCountries", new[] { "Country_CountryID" });
            DropIndex("dbo.OrganizationCountries", new[] { "Organization_OrganizationID" });
            DropTable("dbo.OrganizationCountries");
            CreateIndex("dbo.Organizations", "Homeland_CountryID");
            AddForeignKey("dbo.Organizations", "Homeland_CountryID", "dbo.Countries", "CountryID");
        }
    }
}
