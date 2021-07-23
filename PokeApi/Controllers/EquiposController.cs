using PokeApi.Models;
using Services.Model;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PokeApi.Controllers
{
    /*
     ..:: API Entrenadores ::..
    - Permite crear, obtener, actualizar y eliminar equipos.
    - Todos los métodos realizan su lógica de operación a través de su respectivo servicio en la biblioteca de clases "Services"

     */
    [Route("api/equipos")]
    [EnableCors("*", "*", "*")]
    public class EquiposController : ApiController
    {
        private PokemonEntities entities = new PokemonEntities();

        public IHttpActionResult Get()
        {
            try
            {
                List<Equipos> equipos = entities.Equipos.ToList();
                List<Equipo> equipo = equipos.Select(p => new Equipo
                {
                    ID_Equipos = p.ID_Equipos,
                    nombreEquipo = p.nombreEquipo,
                    entrenador = p.entrenador,
                    primerPokemon = p.primerPokemon,
                    segundoPokemon = p.segundoPokemon,
                    tercerPokemon = p.tercerPokemon,
                    cuartoPokemon = p.cuartoPokemon,
                    quintoPokemon = p.quintoPokemon,
                    sextoPokemon = p.sextoPokemon
            }).ToList();

                return Ok(equipo);
            }
            catch (Exception e)
            {
                String error = e.Message;
                return BadRequest("Error: " + error);
            }
        }

        [Route("api/equipos/create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Equipo equipo)
        {
            try
            {
                EquipoService service = new EquipoService();

                Equipos equipos = new Equipos();
                equipos.nombreEquipo = equipo.nombreEquipo;
                equipos.entrenador = equipo.entrenador;
                equipos.primerPokemon = equipo.primerPokemon;
                equipos.segundoPokemon = equipo.segundoPokemon;
                equipos.tercerPokemon = equipo.tercerPokemon;
                equipos.cuartoPokemon = equipo.cuartoPokemon;
                equipos.quintoPokemon = equipo.quintoPokemon;
                equipos.sextoPokemon = equipo.sextoPokemon;

                service.Create(equipos);
                return Ok();
            }
            catch (Exception e)
            {
                string error = e.Message;
                return BadRequest("Error: " + error);
            }
        }

        [Route("api/equipos/delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                EquipoService service = new EquipoService();
                service.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                string error = e.Message;
                return BadRequest("Error: " + error);
            }
        }

        [Route("api/equipos/update")]
        [HttpPost]
        public IHttpActionResult Update([FromBody] Equipo equipo)
        {
            try
            {
                EquipoService service = new EquipoService();

                Equipos equipos = new Equipos();
                equipos.ID_Equipos = equipo.ID_Equipos;
                equipos.nombreEquipo = equipo.nombreEquipo;
                equipos.entrenador = equipo.entrenador;
                equipos.primerPokemon = equipo.primerPokemon;
                equipos.segundoPokemon = equipo.segundoPokemon;
                equipos.tercerPokemon = equipo.tercerPokemon;
                equipos.cuartoPokemon = equipo.cuartoPokemon;
                equipos.quintoPokemon = equipo.quintoPokemon;
                equipos.sextoPokemon = equipo.sextoPokemon;

                service.Update(equipos);
                return Ok();
            }
            catch (Exception e)
            {
                string error = e.Message;
                return BadRequest("Error: " + error);
            }
        }
    }
}

