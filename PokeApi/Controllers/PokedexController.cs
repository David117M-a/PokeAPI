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
     ..:: API POKEDEX ::..
    - Permite acceder a todos los Pokemones disponibles en base de datos y a los entrenadores de un Pokemon específico.
    - Todos los métodos realizan su lógica de operación a través de su respectivo servicio en la biblioteca de clases "Services"

     */
    [Route("api/pokedex")]
    [EnableCors("*", "*", "*")]
    public class PokedexController : ApiController
    {
        private PokemonEntities entities = new PokemonEntities();
        private PokemonService pokemonService = new PokemonService();

        public IHttpActionResult Get()
        {
            try
            {
                List<Pokedex> pokedexes = pokemonService.Get();
                List<Pokemon> pokemones = pokedexes.Select(p => new Pokemon
                {
                    ID_Pokedex = p.ID_Pokedex,
                    nombrePokemon = p.nombrePokemon,
                    alturaMetros = p.alturaMetros,
                    categoria = p.categoria,
                    pesoKg = p.pesoKg,
                    habilidad = p.habilidad,
                    sexo = p.sexo,
                    tipo = p.tipo,
                    debilidad = p.debilidad
                }).ToList();

                return Ok(pokemones);
            }
            catch (Exception e)
            {
                String error = e.Message;
                return BadRequest("Error: " + error);
            }
        }

        public IHttpActionResult Get(string nombre)
        {
            try
            {
                List<Pokedex> pokedexes = pokemonService.Get(nombre);
                List<Pokemon> pokemones = pokedexes.Select(p => new Pokemon
                {
                    ID_Pokedex = p.ID_Pokedex,
                    nombrePokemon = p.nombrePokemon,
                    alturaMetros = p.alturaMetros,
                    categoria = p.categoria,
                    pesoKg = p.pesoKg,
                    habilidad = p.habilidad,
                    sexo = p.sexo,
                    tipo = p.tipo,
                    debilidad = p.debilidad
                }
                ).ToList();

                return Ok(pokemones);
            }
            catch (Exception e)
            {
                String error = e.Message;
                return BadRequest("Error: " + error);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                List<Pokedex> pokedexes = pokemonService.Get(id);
                List<Pokemon> pokemones = pokedexes.Select(p => new Pokemon
                {
                    ID_Pokedex = p.ID_Pokedex,
                    nombrePokemon = p.nombrePokemon,
                    alturaMetros = p.alturaMetros,
                    categoria = p.categoria,
                    pesoKg = p.pesoKg,
                    habilidad = p.habilidad,
                    sexo = p.sexo,
                    tipo = p.tipo,
                    debilidad = p.debilidad
                }
                ).ToList();



                return Ok(pokemones);
            }
            catch (Exception e)
            {
                String error = e.Message;
                return BadRequest("Error: " + error);
            }
        }

        [Route("api/pokedex/entrenadores")]
        public IHttpActionResult GetEntrenadores(string nombre)
        {
            try
            {
                EntrenadorService entrenadorService = new EntrenadorService();
                EquipoService equipoService = new EquipoService();

                List<Equipos> equipos = equipoService.Get();
                Pokedex pokedex = pokemonService.GetOnlyOne(nombre);
                List<Entrenador> entrenadores = new List<Entrenador>();

                foreach (Equipos e in equipos)
                {

                    if (e.primerPokemon == pokedex.ID_Pokedex || e.segundoPokemon == pokedex.ID_Pokedex
                    || e.tercerPokemon == pokedex.ID_Pokedex || e.cuartoPokemon == pokedex.ID_Pokedex
                    || e.quintoPokemon == pokedex.ID_Pokedex || e.sextoPokemon == pokedex.ID_Pokedex)
                    {
                        Entrenadore entrenadore = entrenadorService.Get(e.entrenador);
                        entrenadores.Add(new Entrenador
                        {
                            ID_Entrenadores = entrenadore.ID_Entrenadores,
                            username = entrenadore.username,
                            fullname = entrenadore.fullname,
                            email = entrenadore.email,
                            userPass = entrenadore.userPass
                        });
                    }

                }

                return Ok(entrenadores);
            }
            catch (Exception e)
            {
                String error = e.Message;
                return BadRequest("Error: " + error);
            }
        }

        [Route("api/pokedex/entrenadores")]
        public IHttpActionResult GetEntrenadores(int id)
        {
            try
            {
                EntrenadorService entrenadorService = new EntrenadorService();
                EquipoService equipoService = new EquipoService();

                List<Equipos> equipos = equipoService.Get();
                Pokedex pokedex = pokemonService.GetOnlyOne(id);
                List<Entrenador> entrenadores = new List<Entrenador>();

                foreach (Equipos e in equipos)
                {

                    if (e.primerPokemon == pokedex.ID_Pokedex || e.segundoPokemon == pokedex.ID_Pokedex
                    || e.tercerPokemon == pokedex.ID_Pokedex || e.cuartoPokemon == pokedex.ID_Pokedex
                    || e.quintoPokemon == pokedex.ID_Pokedex || e.sextoPokemon == pokedex.ID_Pokedex)
                    {
                        Entrenadore entrenadore = entrenadorService.Get(e.entrenador);
                        entrenadores.Add(new Entrenador
                        {
                            ID_Entrenadores = entrenadore.ID_Entrenadores,
                            username = entrenadore.username,
                            fullname = entrenadore.fullname,
                            email = entrenadore.email,
                            userPass = entrenadore.userPass
                        });
                    }

                }

                return Ok(entrenadores);
            }
            catch (Exception e)
            {
                String error = e.Message;
                return BadRequest("Error: " + error);
            }
        }
    }
}
