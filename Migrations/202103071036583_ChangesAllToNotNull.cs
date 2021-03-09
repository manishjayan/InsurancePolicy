namespace InsurancePolicy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesAllToNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Policies", "SumAssured", c => c.Double(nullable: false));
            AlterColumn("dbo.Policies", "PremiumDueDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Policies", "PolicyTerm", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Policies", "PolicyTerm", c => c.Int());
            AlterColumn("dbo.Policies", "PremiumDueDate", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Policies", "SumAssured", c => c.Double());
        }
    }
}
