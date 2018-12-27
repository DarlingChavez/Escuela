namespace Escuela.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CuroUpdateParalelo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Curso", "Paralelo", c => c.String(nullable: false, maxLength: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Curso", "Paralelo", c => c.String(nullable: false, maxLength: 3));
        }
    }
}
