namespace Escuela.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Escuela.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DbContextEscuela>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DbContextEscuela context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            System.Collections.Generic.IList<Curso> cursos = new System.Collections.Generic.List<Curso>();
            cursos.Add(new Curso()
            {
                Descripcion = "Octavo de basica",
                Especializacion = GlobalWords.Especializacion.Basica,
                Nivel = 8,
                Paralelo = "A",
                Estado = GlobalWords.Status.Activo
            });
            cursos.Add(new Curso()
            {
                Descripcion = "Noveno de basica",
                Especializacion = GlobalWords.Especializacion.Basica,                
                Nivel = 9,
                Paralelo = "B",
                Estado = GlobalWords.Status.Activo
            });
            cursos.Add(new Curso()
            {
                Descripcion = "Decimo de basica",
                Especializacion = GlobalWords.Especializacion.Basica,
                Nivel = 10,
                Paralelo = "C",
                Estado = GlobalWords.Status.Activo
            });
            cursos.Add(new Curso()
            {
                Descripcion = "Primero de Bachillerato",
                Especializacion = GlobalWords.Especializacion.Bachillerato,
                Nivel = 1,
                Paralelo = "A",
                Estado = GlobalWords.Status.Activo
            });
            cursos.Add(new Curso()
            {
                Descripcion = "Segundo de Bachillerato",
                Especializacion = GlobalWords.Especializacion.Bachillerato,
                Nivel = 2,
                Paralelo = "A",
                Estado = GlobalWords.Status.Activo
            });
            cursos.Add(new Curso()
            {
                Descripcion = "Tercero de Bachillerato",
                Especializacion = GlobalWords.Especializacion.Bachillerato,
                Nivel = 3,
                Paralelo = "A",
                Estado = GlobalWords.Status.Activo
            });
            context.Curso.AddRange(cursos);
            context.SaveChanges();
            //base.Seed(context);

        }
    }
}
