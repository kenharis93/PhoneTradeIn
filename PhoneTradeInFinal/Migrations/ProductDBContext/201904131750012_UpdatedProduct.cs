namespace PhoneTradeInFinal.Migrations.ProductDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Photo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Photo", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
