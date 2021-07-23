using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokeApi.Models
{
    public class Entrenador
    {
        public int ID_Entrenadores { get; set; }
        public string username { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string userPass { get; set; }
    }
}