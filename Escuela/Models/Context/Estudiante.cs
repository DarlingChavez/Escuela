namespace Escuela.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Estudiante")]
    public partial class Estudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstudiante { get; set; }

        [Required]
        [StringLength(10)]
        public string Cedula { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(1)]
        public string Genero { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaCumpleanhos { get; set; }

        public int IdCurso { get; set; }

        public int IdRepresentante { get; set; }

        [StringLength(10)]
        public string Telefono { get; set; }

        [StringLength(120)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

        [StringLength(50)]
        [Display(Name = "Ingrese el email")]
        public string Email { get; set; }

        [StringLength(10)]
        [Display(Name = "Ingrese la clave")]
        public string Password { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual Representante Representante { get; set; }
    }
}
