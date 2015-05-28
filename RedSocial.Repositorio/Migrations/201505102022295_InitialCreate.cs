namespace RedSocial.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SolicitudAmistads",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FechaSolicitud = c.DateTime(nullable: false),
                        FechaAmistad = c.DateTime(nullable: false),
                        AceptaSolicitud = c.Boolean(nullable: false),
                        usuario_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.usuario_Id)
                .Index(t => t.usuario_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 40),
                        Email = c.String(nullable: false),
                        Foto = c.String(nullable: false),
                        NombreUsuario = c.String(nullable: false, maxLength: 20),
                        Contraseña = c.String(nullable: false),
                        BloqueoCuenta = c.Boolean(nullable:false),
                        intentosFallidos = c.String(nullable:false),
                        Usuario_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SolicitudAmistads", "usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.Usuarios", new[] { "Usuario_Id" });
            DropIndex("dbo.SolicitudAmistads", new[] { "usuario_Id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.SolicitudAmistads");
        }
    }
}
