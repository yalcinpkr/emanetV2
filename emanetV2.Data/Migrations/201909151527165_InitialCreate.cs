namespace emanetV2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnimalSizeId = c.Int(),
                        AnimalTypeId = c.Int(),
                        Note = c.String(),
                        StatusId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnimalSizes", t => t.AnimalSizeId)
                .ForeignKey("dbo.AnimalTypes", t => t.AnimalTypeId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.AnimalSizeId)
                .Index(t => t.AnimalTypeId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.AnimalSizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StatusId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AnimalTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StatusId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slug = c.String(),
                        Description = c.String(),
                        Photo = c.String(),
                        Note = c.String(),
                        AnimalTypeId = c.Int(nullable: false),
                        AnimalSizeId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnimalSizes", t => t.AnimalSizeId)
                .ForeignKey("dbo.AnimalTypes", t => t.AnimalTypeId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.AnimalTypeId)
                .Index(t => t.AnimalSizeId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Publications", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Publications", "AnimalTypeId", "dbo.AnimalTypes");
            DropForeignKey("dbo.Publications", "AnimalSizeId", "dbo.AnimalSizes");
            DropForeignKey("dbo.Animals", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Animals", "AnimalTypeId", "dbo.AnimalTypes");
            DropForeignKey("dbo.AnimalTypes", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Animals", "AnimalSizeId", "dbo.AnimalSizes");
            DropForeignKey("dbo.AnimalSizes", "StatusId", "dbo.Status");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Publications", new[] { "StatusId" });
            DropIndex("dbo.Publications", new[] { "AnimalSizeId" });
            DropIndex("dbo.Publications", new[] { "AnimalTypeId" });
            DropIndex("dbo.AnimalTypes", new[] { "StatusId" });
            DropIndex("dbo.AnimalSizes", new[] { "StatusId" });
            DropIndex("dbo.Animals", new[] { "StatusId" });
            DropIndex("dbo.Animals", new[] { "AnimalTypeId" });
            DropIndex("dbo.Animals", new[] { "AnimalSizeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Publications");
            DropTable("dbo.AnimalTypes");
            DropTable("dbo.Status");
            DropTable("dbo.AnimalSizes");
            DropTable("dbo.Animals");
        }
    }
}
