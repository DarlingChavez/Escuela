namespace Escuela.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Escuela.Models;
    using System.Collections.Generic;

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

            if (!context.Curso.Any())
            {
                IList<Curso> cursos = GetListCursos();
                context.Curso.AddRange(cursos);
                context.SaveChanges();
            }
            if (!context.Representante.Any())
            {
                IList<Representante> representantes = GetListRepresentantes();
                context.Representante.AddRange(representantes);
                context.SaveChanges();
            }
            if (!context.Estudiante.Any())
            {
                IList<Estudiante> estudiantes = GetListEstudiantes();
                context.Estudiante.AddRange(estudiantes);
                context.SaveChanges();
            }

            //base.Seed(context);

        }

        private IList<Curso> GetListCursos()
        {
            IList<Curso> cursos = new List<Curso>();
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
            return cursos;
        }

        private IList<Representante> GetListRepresentantes()
        {
            IList<Representante> representantes = new List<Representante>()
            {
                new Representante()
                {
                    Apellido = "Hernandez",
                    Nombre = "Joaquim",
                    Cedula = "0913674536",
                    Direccion = "Tarrasa Espanha",
                    Email = "padredexavi@gmail.com",
                    Password = "123",
                    Telefono = "09123",
                    Genero = GlobalWords.Gender.Masculino,
                    FechaCumpleanhos = new DateTime(1947,7,26),
                    Estado = GlobalWords.Status.Activo
                },
                new Representante()
                {
                    Apellido = "Iniesta",
                    Nombre = "Jose Antonio",
                    Cedula = "0913478956",
                    Email = "padredeiniesta@gmail.com",
                    Password = "123",
                    Direccion = "FuenteAlbilla Espanha",
                    Telefono = "09321",
                    FechaCumpleanhos = new DateTime(1984,5,11),
                    Genero = GlobalWords.Gender.Masculino,
                    Estado = GlobalWords.Status.Activo
                }
            };
            return representantes;
        }

        private IList<Estudiante> GetListEstudiantes()
        {
            IList<Estudiante> estudiantes = new List<Estudiante>()
            {
                new Estudiante()
                {
                    Apellido = "Hernandez",
                    Nombre = "Xavi",
                    Cedula = "0923456423",
                    IdCurso = 1,
                    IdRepresentante = 1,
                    Direccion = "Tarrasa Espanha",
                    Email = "darling.chavez@hotmail.com",
                    Password = "123",
                    Telefono = "09123",
                    Genero = GlobalWords.Gender.Masculino,
                    FechaCumpleanhos = new DateTime(1980,1,25),
                    Estado = GlobalWords.Status.Activo
                },
                new Estudiante()
                {
                    Apellido = "Iniesta",
                    Nombre = "Andres",
                    Cedula = "0924324532",
                    IdCurso = 2,
                    IdRepresentante = 2,
                    Email = "elpeladoiniesta@gmail.com",
                    Password = "123",
                    Direccion = "FuenteAlbilla Espanha",
                    Telefono = "09321",
                    FechaCumpleanhos = new DateTime(1984,5,11),
                    Genero = GlobalWords.Gender.Masculino,
                    Estado = GlobalWords.Status.Activo
                }
            };
            return estudiantes;
        }
    }
}
