using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokeApi.Models
{
    public class Pokemon
    {
        public int ID_Pokedex { get; set; }
        public string nombrePokemon { get; set; }
        public double alturaMetros { get; set; }
        public string categoria { get; set; }
        public double pesoKg { get; set; }
        public string habilidad { get; set; }
        public string sexo { get; set; }
        public string tipo { get; set; }
        public string debilidad { get; set; }
    }
}