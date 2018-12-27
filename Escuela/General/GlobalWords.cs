using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escuela
{
    /// <summary>
    /// Constantes globales
    /// </summary>
    public class GlobalWords
    {
        
        /// <summary>
        /// Estado (Activo/Inactivo)
        /// </summary>
        public static class Status
        {
            public const string Activo = "A";
            public const string Inactivo = "I";
        }

        /// <summary>
        /// Identifica el tipo de usuario (Estudiante/Profesor/Representante/Personal administrativo)
        /// </summary>
        public static class UserType
        {
            public const string Administrativo = "A";
            public const string Estudiante = "E";
            public const string Profesor = "P";
            public const string Representante = "R";
        }

        /// <summary>
        /// Genero (Masculino/Femenino)
        /// </summary>
        public static class Gender
        {
            public const string Masculino = "M";
            public const string Femenino = "F";
        }

        /// <summary>
        /// Basico/Diversificado
        /// </summary>
        public static class Especializacion
        {
            public const string Basica = "A";
            public const string Bachillerato = "B";
        }

    }
}
