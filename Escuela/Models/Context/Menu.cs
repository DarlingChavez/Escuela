namespace Escuela.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdMenu { get; set; }

        [Required]
        [StringLength(60)]
        public string Descripcion { get; set; }

        public int IdPapa { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

        public byte Prioridad { get; set; }

        public bool Ejecuta { get; set; }

        [StringLength(60)]
        public string NameSpace { get; set; }

        [StringLength(60)]
        public string Formulario { get; set; }
    }
}
