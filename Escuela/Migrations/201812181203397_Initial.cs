namespace Escuela.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrativo",
                c => new
                    {
                        IdAdministrativo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Cedula = c.String(nullable: false, maxLength: 10),
                        Genero = c.String(nullable: false, maxLength: 1),
                        Telefono = c.String(nullable: false, maxLength: 10),
                        Direccion = c.String(nullable: false, maxLength: 120),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 10),
                        Estado = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.IdAdministrativo);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        IdCurso = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Nivel = c.Byte(nullable: false),
                        Paralelo = c.String(nullable: false, maxLength: 3),
                        Especializacion = c.String(nullable: false, maxLength: 1),
                        Estado = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.IdCurso);
            
            CreateTable(
                "dbo.Estudiante",
                c => new
                    {
                        IdEstudiante = c.Int(nullable: false, identity: true),
                        Cedula = c.String(nullable: false, maxLength: 10),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Genero = c.String(nullable: false, maxLength: 1),
                        FechaCumpleanhos = c.DateTime(nullable: false),
                        IdCurso = c.Int(nullable: false),
                        IdRepresentante = c.Int(nullable: false),
                        Telefono = c.String(maxLength: 10),
                        Direccion = c.String(maxLength: 120),
                        Estado = c.String(nullable: false, maxLength: 1),
                        Email = c.String(maxLength: 50),
                        Password = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.IdEstudiante)
                .ForeignKey("dbo.Representante", t => t.IdRepresentante)
                .ForeignKey("dbo.Curso", t => t.IdCurso)
                .Index(t => t.IdCurso)
                .Index(t => t.IdRepresentante);
            
            CreateTable(
                "dbo.Representante",
                c => new
                    {
                        IdRepresentante = c.Int(nullable: false, identity: true),
                        Cedula = c.String(nullable: false, maxLength: 10),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        FechaCumpleanhos = c.DateTime(nullable: false),
                        Genero = c.String(nullable: false, maxLength: 1),
                        Telefono = c.String(maxLength: 10),
                        Direccion = c.String(maxLength: 120),
                        Email = c.String(maxLength: 50),
                        Password = c.String(maxLength: 10),
                        Estado = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.IdRepresentante);
            
            CreateTable(
                "dbo.Materia",
                c => new
                    {
                        IdMateria = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        Nivel = c.Byte(nullable: false),
                        Especializacion = c.String(nullable: false, maxLength: 1),
                        Estado = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.IdMateria);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        IdMenu = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 60),
                        IdPapa = c.Int(nullable: false),
                        Estado = c.String(nullable: false, maxLength: 1),
                        Prioridad = c.Byte(nullable: false),
                        Ejecuta = c.Boolean(nullable: false),
                        NameSpace = c.String(maxLength: 60),
                        Formulario = c.String(maxLength: 60),
                    })
                .PrimaryKey(t => t.IdMenu);
            
            CreateTable(
                "dbo.Profesor",
                c => new
                    {
                        IdProfesor = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Cedula = c.String(nullable: false, maxLength: 10),
                        Genero = c.String(nullable: false, maxLength: 1),
                        FechaCumpleanhos = c.DateTime(nullable: false),
                        Telefono = c.String(nullable: false, maxLength: 10),
                        Direccion = c.String(nullable: false, maxLength: 120),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 10),
                        Estado = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.IdProfesor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estudiante", "IdCurso", "dbo.Curso");
            DropForeignKey("dbo.Estudiante", "IdRepresentante", "dbo.Representante");
            DropIndex("dbo.Estudiante", new[] { "IdRepresentante" });
            DropIndex("dbo.Estudiante", new[] { "IdCurso" });
            DropTable("dbo.Profesor");
            DropTable("dbo.Menu");
            DropTable("dbo.Materia");
            DropTable("dbo.Representante");
            DropTable("dbo.Estudiante");
            DropTable("dbo.Curso");
            DropTable("dbo.Administrativo");
        }

    }

}
