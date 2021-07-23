using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokeApi.Models
{
    public class Equipo
    {
        public int ID_Equipos { get; set; }
        public string nombreEquipo { get; set; }
        public int entrenador { get; set; }
        public int primerPokemon { get; set; }
        public int segundoPokemon { get; set; }
        public int tercerPokemon { get; set; }
        public int cuartoPokemon { get; set; }
        public int quintoPokemon { get; set; }
        public int sextoPokemon { get; set; }
    }
}