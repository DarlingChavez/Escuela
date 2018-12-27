namespace Escuela.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;

    public class User
    {

        
        [Display(Name = "Ingrese el email")]
        public string Email { get; set; }

        
        [Display(Name = "Ingrese la clave")]
        public string Password { get; set; }

        /// <summary>
        /// Obtiene o establece la descripcion larga del tipo de usuario
        /// </summary>
        public string TipoUsuario
        {
            get {
                switch (UserType)
                {
                    case "A":
                        return "Administrativo";
                    case "E":
                        return "Estudiante";
                    case "P":
                        return "Pofesor";
                    case "R":
                        return "Representante";
                    default: return "Desconocido";
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la clave de tipo de usuario
        /// </summary>
        public string UserType { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompleto { get { return string.Format("{0} {1}",Nombres,Apellidos); } }

        public bool Remenber { get; set; }

    }
}
