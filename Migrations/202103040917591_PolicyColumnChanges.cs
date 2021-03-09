namespace InsurancePolicy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PolicyColumnChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Policies", "Owner", c => c.String(maxLength: 50));
            AddColumn("dbo.Policies", "PolicyTerm", c => c.Int());
            AlterColumn("dbo.Policies", "Beneficiary", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Policies", "Beneficiary", c => c.String(maxLength: 30, unicode: false));
            DropColumn("dbo.Policies", "PolicyTerm");
            DropColumn("dbo.Policies", "Owner");
        }
    }
}
