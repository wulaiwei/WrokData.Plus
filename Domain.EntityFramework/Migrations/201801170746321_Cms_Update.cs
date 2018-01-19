namespace Domain.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cms_Update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ContentDescriptionField", "CreateTime");
            DropColumn("dbo.ContentDescriptionField", "CreateUserId");
            DropColumn("dbo.ContentDescriptionField", "ModifierTime");
            DropColumn("dbo.ContentDescriptionField", "ModifierUserId");
            DropColumn("dbo.ContentDoubleField", "CreateTime");
            DropColumn("dbo.ContentDoubleField", "CreateUserId");
            DropColumn("dbo.ContentDoubleField", "ModifierTime");
            DropColumn("dbo.ContentDoubleField", "ModifierUserId");
            DropColumn("dbo.ContentIntField", "CreateTime");
            DropColumn("dbo.ContentIntField", "CreateUserId");
            DropColumn("dbo.ContentIntField", "ModifierTime");
            DropColumn("dbo.ContentIntField", "ModifierUserId");
            DropColumn("dbo.ContentStringField", "CreateTime");
            DropColumn("dbo.ContentStringField", "CreateUserId");
            DropColumn("dbo.ContentStringField", "ModifierTime");
            DropColumn("dbo.ContentStringField", "ModifierUserId");
            DropColumn("dbo.ContentTextField", "CreateTime");
            DropColumn("dbo.ContentTextField", "CreateUserId");
            DropColumn("dbo.ContentTextField", "ModifierTime");
            DropColumn("dbo.ContentTextField", "ModifierUserId");
            DropColumn("dbo.ContentTimeField", "CreateTime");
            DropColumn("dbo.ContentTimeField", "CreateUserId");
            DropColumn("dbo.ContentTimeField", "ModifierTime");
            DropColumn("dbo.ContentTimeField", "ModifierUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContentTimeField", "ModifierUserId", c => c.String(maxLength: 500));
            AddColumn("dbo.ContentTimeField", "ModifierTime", c => c.DateTime());
            AddColumn("dbo.ContentTimeField", "CreateUserId", c => c.String(maxLength: 500));
            AddColumn("dbo.ContentTimeField", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.ContentTextField", "ModifierUserId", c => c.String(maxLength: 500));
            AddColumn("dbo.ContentTextField", "ModifierTime", c => c.DateTime());
            AddColumn("dbo.ContentTextField", "CreateUserId", c => c.String(maxLength: 500));
            AddColumn("dbo.ContentTextField", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.ContentStringField", "ModifierUserId", c => c.String(maxLength: 500));
            AddColumn("dbo.ContentStringField", "ModifierTime", c => c.DateTime());
            AddColumn("dbo.ContentStringField", "CreateUserId", c => c.String(maxLength: 500));
            AddColumn("dbo.ContentStringField", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.ContentIntField", "ModifierUserId", c => c.String(maxLength: 500));
            AddColumn("dbo.ContentIntField", "ModifierTime", c => c.DateTime());
            AddColumn("dbo.ContentIntField", "CreateUserId", c => c.String(maxLength: 500));
            AddColumn("dbo.ContentIntField", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.ContentDoubleField", "ModifierUserId", c => c.String(maxLength: 500));
            AddColumn("dbo.ContentDoubleField", "ModifierTime", c => c.DateTime());
            AddColumn("dbo.ContentDoubleField", "CreateUserId", c => c.String(maxLength: 500));
            AddColumn("dbo.ContentDoubleField", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.ContentDescriptionField", "ModifierUserId", c => c.String(maxLength: 500));
            AddColumn("dbo.ContentDescriptionField", "ModifierTime", c => c.DateTime());
            AddColumn("dbo.ContentDescriptionField", "CreateUserId", c => c.String(maxLength: 500));
            AddColumn("dbo.ContentDescriptionField", "CreateTime", c => c.DateTime(nullable: false));
        }
    }
}
