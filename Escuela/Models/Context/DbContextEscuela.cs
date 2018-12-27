namespace Escuela.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbContextEscuela : DbContext
    {
        public DbContextEscuela()
            : base("name=DbContextEscuela")
        {
        }

        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<Representante> Representante { get; set; }
        public virtual DbSet<Administrativo> Administrativo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .HasMany(e => e.Estudiantes)
                .WithRequired(e => e.Curso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Representante>()
                .HasMany(e => e.Estudiantes)
                .WithRequired(e => e.Representante)
                .WillCascadeOnDelete(false);
        }
    }
}
