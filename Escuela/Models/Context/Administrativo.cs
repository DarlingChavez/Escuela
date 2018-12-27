using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Escuela.Models
{
    /// <summary>
    /// Personal administrativo
    /// </summary>
    [Table("Administrativo")]
    public class Administrativo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAdministrativo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(10)]
        public string Cedula { get; set; }

        [Required]
        [StringLength(1)]
        public string Genero { get; set; }

        [Required]
        [StringLength(10)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(120)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ingrese el email")]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Ingrese la clave")]
        public string Password { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }
    }
}