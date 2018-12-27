using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Escuela.Models;
namespace Escuela
{
    public sealed class Param
    {
        private readonly static Param _instance = new Param();
        public static Param Instance
        {
            get
            {
                return _instance;
            }
        }
        
        public bool IsLogined { get; set; }
        public User Logueado { get; set; }

    }
}