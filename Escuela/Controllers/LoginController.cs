﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Escuela.Models;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using Escuela.Services;

namespace Escuela.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Ingresar(User usuario)
        {
            LoginService loginService = new LoginService();
            //string email = formCollection["inputEmail"];
            //string password = formCollection["inputPassword"];
            bool existe = loginService.ExisteUsuario(usuario.Email,usuario.Password);
            if (existe)
            {
                if (usuario.Remenber)
                {
                    return RedirectToAction("Contact", "Home");
                }
                return RedirectToAction("About","Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult RecuperarPassword()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ResetarPassword(User user)
        {
            var respuesta = new ResponseModel
            {
                respuesta = true,
                redirect = "/Login/PasswordReseteada",
                error = ""
            };
            LoginService loginService = new LoginService();
            bool existe = loginService.ExisteEmail(user.Email);
            if (!existe)
            {
                ModelState.AddModelError("Login", "El correo ingresado es incorrecto");
                respuesta.respuesta = false;
                respuesta.error = "El correo ingresado es incorrecto";
                return Json(respuesta);
            }
            string emailSistema = ConfigurationManager.AppSettings["Email"];
            string passwordEmail = ConfigurationManager.AppSettings["Password"];
            string servidorSmtp = ConfigurationManager.AppSettings["ServidorSMTP"];
            int puertoSmtp = Convert.ToInt32(ConfigurationManager.AppSettings["PuertoSMTP"]);
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress(emailSistema);
            correo.To.Add(user.Email);
            correo.Subject = ConfigurationManager.AppSettings["SchoolName"] + " - " + "Recuperar password";
            string cuerpo = "Se ha ingresado su correo para recuperar la clave del sistema SisCool. La clave es: ";
            string password = loginService.GetPassword(user.Email);
            cuerpo += password;
            correo.Body = cuerpo;
            correo.Priority = MailPriority.Normal;
            // smtp - el servidor de correo depende si es gmail o hotmail, etc
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(emailSistema, passwordEmail);
            smtpClient.Host = servidorSmtp;
            smtpClient.Port = puertoSmtp;
            smtpClient.EnableSsl = true;

            smtpClient.Send(correo);

            return RedirectToAction("PasswordReseteada", "Login");
        }

        public ActionResult PasswordReseteada()
        {
            return View();
        }

    }
}
