namespace Database_Week1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Country : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        CountryCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryID);
            
            AddColumn("dbo.Organizations", "Homeland_CountryID", c => c.Int());
            CreateIndex("dbo.Organizations", "Homeland_CountryID");
            AddForeignKey("dbo.Organizations", "Homeland_CountryID", "dbo.Countries", "CountryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizations", "Homeland_CountryID", "dbo.Countries");
            DropIndex("dbo.Organizations", new[] { "Homeland_CountryID" });
            DropColumn("dbo.Organizations", "Homeland_CountryID");
            DropTable("dbo.Countries");
        }
    }
}
