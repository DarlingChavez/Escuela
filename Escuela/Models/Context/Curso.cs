namespace Escuela.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Curso")]
    public partial class Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curso()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCurso { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        public byte Nivel { get; set; }

        [Required]
        [StringLength(1)]
        public string Paralelo { get; set; }

        [Required]
        [StringLength(1)]
        public string Especializacion { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
