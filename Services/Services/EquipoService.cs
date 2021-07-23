using Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    /*
     
    ..:: EquipoService ::..
    - Realiza todas las operaciones con la entidad Equipos.
     
     */
    public class EquipoService
    {
        PokemonEntities entities = new PokemonEntities();

        public List<Equipos> Get()
        {
            try
            {
                List<Equipos> equipos = entities.Equipos.ToList();
                return equipos;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }
        public bool Create(Equipos equipos)
        {
            bool respuesta = false;
            try
            {
                entities.Equipos.Add(equipos);
                entities.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return respuesta;
        }

        public bool Delete(int id)
        {
            bool respuesta = false;
            try
            {
                Equipos equipos = entities.Equipos.Where(p => p.ID_Equipos == id).First();
                entities.Equipos.Remove(equipos);
                entities.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return respuesta;
        }

        public bool Update(Equipos equipos)
        {
            bool respuesta = false;
            try
            {
                var equipo = entities.Equipos.Where(p => p.ID_Equipos == equipos.ID_Equipos).First();
                equipo.nombreEquipo = equipos.nombreEquipo;
                equipo.entrenador = equipos.entrenador;
                equipo.primerPokemon = equipos.primerPokemon;
                equipo.segundoPokemon = equipos.segundoPokemon;
                equipo.tercerPokemon = equipos.tercerPokemon;
                equipo.cuartoPokemon = equipos.cuartoPokemon;
                equipo.quintoPokemon = equipos.quintoPokemon;
                equipo.sextoPokemon = equipos.sextoPokemon;

                entities.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return respuesta;
        }
    }
}
