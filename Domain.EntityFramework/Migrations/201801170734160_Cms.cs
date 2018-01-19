namespace Domain.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 150),
                        ModelId = c.String(maxLength: 150),
                        Name = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                        ParentId = c.String(maxLength: 150),
                        Layer = c.Int(nullable: false),
                        HasLevel = c.Boolean(nullable: false),
                        Sort = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 50),
                        FormTemplate = c.String(maxLength: 4000),
                        ListTemplate = c.String(maxLength: 4000),
                        FormJson = c.String(maxLength: 4000),
                        ListJson = c.String(maxLength: 4000),
                        ListHead = c.String(maxLength: 4000),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.String(maxLength: 500),
                        ModifierTime = c.DateTime(),
                        ModifierUserId = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Model", t => t.ModelId)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.Content",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 150),
                        ModelId = c.String(maxLength: 150),
                        CategoryId = c.String(maxLength: 150),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.String(maxLength: 500),
                        ModifierTime = c.DateTime(),
                        ModifierUserId = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Model", t => t.ModelId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.ModelId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ContentDescriptionField",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 150),
                        ContentId = c.String(maxLength: 150),
                        FieldCode = c.String(maxLength: 50),
                        FieldValue = c.String(maxLength: 500),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.String(maxLength: 500),
                        ModifierTime = c.DateTime(),
                        ModifierUserId = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.ContentDoubleField",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 150),
                        ContentId = c.String(maxLength: 150),
                        FieldCode = c.String(maxLength: 50),
                        FieldValue = c.Double(),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.String(maxLength: 500),
                        ModifierTime = c.DateTime(),
                        ModifierUserId = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.ContentIntField",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 150),
                        ContentId = c.String(maxLength: 150),
                        FieldCode = c.String(maxLength: 50),
                        FieldValue = c.Int(),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.String(maxLength: 500),
                        ModifierTime = c.DateTime(),
                        ModifierUserId = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.ContentStringField",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 150),
                        ContentId = c.String(maxLength: 150),
                        FieldCode = c.String(maxLength: 50),
                        FieldValue = c.String(maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.String(maxLength: 500),
                        ModifierTime = c.DateTime(),
                        ModifierUserId = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.ContentTextField",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 150),
                        ContentId = c.String(maxLength: 150),
                        FieldCode = c.String(maxLength: 50),
                        FieldValue = c.String(maxLength: 4000),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.String(maxLength: 500),
                        ModifierTime = c.DateTime(),
                        ModifierUserId = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.ContentTimeField",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 150),
                        ContentId = c.String(maxLength: 150),
                        FieldCode = c.String(maxLength: 50),
                        FieldValue = c.DateTime(),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.String(maxLength: 500),
                        ModifierTime = c.DateTime(),
                        ModifierUserId = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Content", t => t.ContentId, cascadeDelete: true)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Model",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 150),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 50),
                        Status = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 200),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.String(maxLength: 500),
                        ModifierTime = c.DateTime(),
                        ModifierUserId = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModelField",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 150),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 50),
                        ControlType = c.String(nullable: false, maxLength: 50),
                        DefaultValue = c.String(maxLength: 50),
                        ValidTipMsg = c.String(maxLength: 200),
                        ValidPattern = c.String(maxLength: 500),
                        ValidErrorMsg = c.String(maxLength: 200),
                        IsSystemField = c.Boolean(),
                        ItemOption = c.String(maxLength: 500),
                        HtmlTemplate = c.String(maxLength: 500),
                        FieldType = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserId = c.String(maxLength: 500),
                        ModifierTime = c.DateTime(),
                        ModifierUserId = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModelModelField",
                c => new
                    {
                        ModelFieldId = c.String(nullable: false, maxLength: 150),
                        ModelId = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => new { t.ModelFieldId, t.ModelId })
                .ForeignKey("dbo.ModelField", t => t.ModelFieldId, cascadeDelete: true)
                .ForeignKey("dbo.Model", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelFieldId)
                .Index(t => t.ModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Content", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.ModelModelField", "ModelId", "dbo.Model");
            DropForeignKey("dbo.ModelModelField", "ModelFieldId", "dbo.ModelField");
            DropForeignKey("dbo.Content", "ModelId", "dbo.Model");
            DropForeignKey("dbo.Category", "ModelId", "dbo.Model");
            DropForeignKey("dbo.ContentTimeField", "ContentId", "dbo.Content");
            DropForeignKey("dbo.ContentTextField", "ContentId", "dbo.Content");
            DropForeignKey("dbo.ContentStringField", "ContentId", "dbo.Content");
            DropForeignKey("dbo.ContentIntField", "ContentId", "dbo.Content");
            DropForeignKey("dbo.ContentDoubleField", "ContentId", "dbo.Content");
            DropForeignKey("dbo.ContentDescriptionField", "ContentId", "dbo.Content");
            DropIndex("dbo.ModelModelField", new[] { "ModelId" });
            DropIndex("dbo.ModelModelField", new[] { "ModelFieldId" });
            DropIndex("dbo.ContentTimeField", new[] { "ContentId" });
            DropIndex("dbo.ContentTextField", new[] { "ContentId" });
            DropIndex("dbo.ContentStringField", new[] { "ContentId" });
            DropIndex("dbo.ContentIntField", new[] { "ContentId" });
            DropIndex("dbo.ContentDoubleField", new[] { "ContentId" });
            DropIndex("dbo.ContentDescriptionField", new[] { "ContentId" });
            DropIndex("dbo.Content", new[] { "CategoryId" });
            DropIndex("dbo.Content", new[] { "ModelId" });
            DropIndex("dbo.Category", new[] { "ModelId" });
            DropTable("dbo.ModelModelField");
            DropTable("dbo.ModelField");
            DropTable("dbo.Model");
            DropTable("dbo.ContentTimeField");
            DropTable("dbo.ContentTextField");
            DropTable("dbo.ContentStringField");
            DropTable("dbo.ContentIntField");
            DropTable("dbo.ContentDoubleField");
            DropTable("dbo.ContentDescriptionField");
            DropTable("dbo.Content");
            DropTable("dbo.Category");
        }
    }
}
