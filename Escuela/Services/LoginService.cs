using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Escuela.Models;

namespace Escuela.Services
{
    public class LoginService
    {
        /// <summary>
        /// Determina si el email y el password ingresado, le pertenecen a un usuario
        /// </summary>
        /// <param name="email">Correo electronico del usuario</param>
        /// <param name="password">Clave del usuario</param>
        /// <returns>valor booleano</returns>
        public bool ExisteUsuario(string email, string password)
        {
            using(DbContextEscuela dbContext = new DbContextEscuela())
            {
                dbContext.Configuration.AutoDetectChangesEnabled = false;
                dbContext.Configuration.LazyLoadingEnabled = false;
                //consultar representante
                var queryRepresentante = (from entry in dbContext.Representante.AsNoTracking()
                                  where entry.Email.Equals(email) && entry.Password.Equals(password)
                                  select entry.IdRepresentante);
                int countRepresentante = queryRepresentante.Count();
                if (countRepresentante > 0) return true;
                //consultar estudiante
                var queryEstudiante = (from entry in dbContext.Estudiante.AsNoTracking()
                                       where entry.Email.Equals(email) && entry.Password.Equals(password)
                                       select entry.IdEstudiante);
                int countEstudiantes = queryEstudiante.Count();
                if (countEstudiantes > 0) return true;
                //consultar profesor
                var queryProfesor = (from entry in dbContext.Profesor.AsNoTracking()
                                     where entry.Email.Equals(email) && entry.Password.Equals(password)
                                     select entry.IdProfesor);
                int countProfesor = queryProfesor.Count();
                if (countProfesor > 0) return true;
                //consultar personal administrativo
                var queryAdmin = (from entry in dbContext.Administrativo.AsNoTracking()
                                  where entry.Email.Equals(email) && entry.Password.Equals(password)
                                  select entry.IdAdministrativo);
                int countAdmin = queryAdmin.Count();
                if (countAdmin > 0) return true;
            }
            return false;
        }

        /// <summary>
        /// Determina si el email ingresado, le pertenece a un usuario
        /// </summary>
        /// <param name="email">Correo electronico del usuario</param>
        /// <returns>valor booleano</returns>
        public bool ExisteEmail(string email)
        {
            using (DbContextEscuela dbContext = new DbContextEscuela())
            {
                dbContext.Configuration.AutoDetectChangesEnabled = false;
                dbContext.Configuration.LazyLoadingEnabled = false;
                //consultar representante
                var queryRepresentante = (from entry in dbContext.Representante.AsNoTracking()
                                          where entry.Email.Equals(email)
                                          select entry.IdRepresentante);
                int countRepresentante = queryRepresentante.Count();
                if (countRepresentante > 0) return true;
                //consultar estudiante
                var queryEstudiante = (from entry in dbContext.Estudiante.AsNoTracking()
                                       where entry.Email.Equals(email)
                                       select entry.IdEstudiante);
                int countEstudiantes = queryEstudiante.Count();
                if (countEstudiantes > 0) return true;
                //consultar profesor
                var queryProfesor = (from entry in dbContext.Profesor.AsNoTracking()
                                     where entry.Email.Equals(email)
                                     select entry.IdProfesor);
                int countProfesor = queryProfesor.Count();
                if (countProfesor > 0) return true;
                //consultar personal administrativo
                var queryAdmin = (from entry in dbContext.Administrativo.AsNoTracking()
                                  where entry.Email.Equals(email)
                                  select entry.IdAdministrativo);
                int countAdmin = queryAdmin.Count();
                if (countAdmin > 0) return true;
            }
            return false;
        }

        /// <summary>
        /// Obtiene la clave de un usuario a partir de su email
        /// </summary>
        /// <param name="email">correo</param>
        /// <returns>clave</returns>
        public string GetPassword(string email)
        {
            string password;
            using (DbContextEscuela dbContext = new DbContextEscuela())
            {
                dbContext.Configuration.AutoDetectChangesEnabled = false;
                dbContext.Configuration.LazyLoadingEnabled = false;
                
                var query = (from entry in dbContext.Representante.AsNoTracking()
                             where entry.Email.Equals(email)
                             select entry.Password).Union(
                                 from entry in dbContext.Estudiante.AsNoTracking()
                                 where entry.Email.Equals(email)
                                 select entry.Password).Union(
                                     from entry in dbContext.Profesor.AsNoTracking()
                                     where entry.Email.Equals(email)
                                     select entry.Password).Union(
                                         from entry in dbContext.Administrativo.AsNoTracking()
                                         where entry.Email.Equals(email)
                                         select entry.Password);
                password = query.FirstOrDefault();
            }
            return password;
        }

        /// <summary>
        /// Retorna un usuario a partir del email y password
        /// </summary>
        /// <param name="email">correo electronico del usuario</param>
        /// <param name="password">clave del usuario</param>
        /// <returns>Un usuario</returns>
        public User BuscarLogin(string email, string password)
        {
            using(DbContextEscuela dbContext = new DbContextEscuela())
            {
                dbContext.Configuration.AutoDetectChangesEnabled = false;
                dbContext.Configuration.LazyLoadingEnabled = false;
                //buscar email y password entre los representantes
                var queryRepresentante = (from entry in dbContext.Representante.AsNoTracking()
                             where entry.Email.Equals(email) && entry.Password.Equals(password)
                             select new User()
                             {
                                 UserType = GlobalWords.UserType.Representante,
                                 Apellidos = entry.Apellido,
                                 Email = entry.Email,
                                 Nombres = entry.Nombre,
                                 Password = entry.Password
                             });
                if (queryRepresentante.Count() > 0)
                {
                    var userRepresentante = queryRepresentante.FirstOrDefault();
                    return userRepresentante;
                }
                //buscar email y password entre los estudiantes
                var queryEstudiante = (from entry in dbContext.Estudiante.AsNoTracking()
                                          where entry.Email.Equals(email) && entry.Password.Equals(password)
                                          select new User()
                                          {
                                              UserType = GlobalWords.UserType.Estudiante,
                                              Apellidos = entry.Apellido,
                                              Email = entry.Email,
                                              Nombres = entry.Nombre,
                                              Password = entry.Password
                                          });
                if (queryEstudiante.Count() > 0)
                {
                    var userEstudiante = queryEstudiante.FirstOrDefault();
                    return userEstudiante;
                }
                //buscar profesor
                var queryProfesor = (from entry in dbContext.Profesor.AsNoTracking()
                                       where entry.Email.Equals(email) && entry.Password.Equals(password)
                                       select new User()
                                       {
                                           UserType = GlobalWords.UserType.Estudiante,
                                           Apellidos = entry.Apellido,
                                           Email = entry.Email,
                                           Nombres = entry.Nombre,
                                           Password = entry.Password
                                       });
                if (queryProfesor.Count() > 0)
                {
                    var userProfesor = queryProfesor.FirstOrDefault();
                    return userProfesor;
                }
                //buscar personal administrativo
                //buscar profesor
                var queryAdministrativo = (from entry in dbContext.Administrativo.AsNoTracking()
                                     where entry.Email.Equals(email) && entry.Password.Equals(password)
                                     select new User()
                                     {
                                         UserType = GlobalWords.UserType.Estudiante,
                                         Apellidos = entry.Apellido,
                                         Email = entry.Email,
                                         Nombres = entry.Nombre,
                                         Password = entry.Password
                                     });
                if (queryAdministrativo.Count() > 0)
                {
                    var userAdministrativo = queryAdministrativo.FirstOrDefault();
                    return userAdministrativo;
                }
            }
            return null;
        }





    }
}