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
    - Permite crear, obtener, actualizar y eliminar entrenadores.
    - Todos los métodos realizan su lógica de operación a través de su respectivo servicio en la biblioteca de clases "Services"

     */
    [Route("api/entrenadores")]
    [EnableCors("*", "*", "*")]
    public class EntrenadoresController : ApiController
    {
        private PokemonEntities entities = new PokemonEntities();

        public IHttpActionResult Get()
        {
            try
            {
                EntrenadorService service = new EntrenadorService();
                List<Entrenadore> entrenadore = service.Get();
                List<Entrenador> entrenadores = entrenadore.Select(p => new Entrenador
                {
                    ID_Entrenadores = p.ID_Entrenadores,
                    username = p.username,
                    fullname = p.fullname,
                    email = p.email,
                    userPass = p.userPass,
                }).ToList();

                return Ok(entrenadores);
            }
            catch (Exception e)
            {
                String error = e.Message;
                return BadRequest("Error: " + error);
            }
        }

        [Route("api/entrenadores/create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Entrenador entrenador)
        {
            try
            {
                EntrenadorService service = new EntrenadorService();

                Entrenadore entrenadore = new Entrenadore();
                entrenadore.username = entrenador.username;
                entrenadore.fullname = entrenador.fullname;
                entrenadore.email = entrenador.email;
                entrenadore.userPass = entrenador.userPass;

                service.Create(entrenadore);
                return Ok();
            }
            catch (Exception e)
            {
                string error = e.Message;
                return BadRequest("Error: " + error);
            }
        }

        [Route("api/entrenadores/delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                EntrenadorService service = new EntrenadorService();
                service.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                string error = e.Message;
                return BadRequest("Error: " + error);
            }
        }

        [Route("api/entrenadores/update")]
        [HttpPost]
        public IHttpActionResult Update([FromBody] Entrenador entrenador)
        {
            try
            {
                EntrenadorService service = new EntrenadorService();

                Entrenadore entrenadore = new Entrenadore();
                entrenadore.ID_Entrenadores = entrenador.ID_Entrenadores;
                entrenadore.username = entrenador.username;
                entrenadore.fullname = entrenador.fullname;
                entrenadore.email = entrenador.email;
                entrenadore.userPass = entrenador.userPass;

                service.Update(entrenadore);
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
