namespace Escuela.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Materia")]
    public partial class Materia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMateria { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        public byte Nivel { get; set; }

        [Required]
        [StringLength(1)]
        public string Especializacion { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }
    }
}
