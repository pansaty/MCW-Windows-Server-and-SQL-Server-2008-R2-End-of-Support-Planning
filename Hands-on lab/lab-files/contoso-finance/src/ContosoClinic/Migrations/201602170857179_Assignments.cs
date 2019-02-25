namespace ContosoClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Assignments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserCustomers",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Customer_CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Customer_CustomerID })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Customer_CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserCustomers", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.ApplicationUserCustomers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserCustomers", new[] { "Customer_CustomerID" });
            DropIndex("dbo.ApplicationUserCustomers", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserCustomers");
        }
    }
}
