using Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    /*
     
    ..:: EntrenadorService ::..
    - Realiza todas las operaciones con la entidad Entrenadore.
     
     */
    public class EntrenadorService
    {
        PokemonEntities entities = new PokemonEntities();

        public List<Entrenadore> Get()
        {
            try
            {
                List<Entrenadore> entrenadore = entities.Entrenadores.ToList();
                return entrenadore;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }

        public Entrenadore Get(int id)
        {
            try
            {
                Entrenadore entrenadores = new Entrenadore();
                foreach (Entrenadore e in entities.Entrenadores.ToList())
                {
                    if (e.ID_Entrenadores.ToString().Contains(id.ToString()))
                    {
                        entrenadores = new Entrenadore
                        {
                            ID_Entrenadores = e.ID_Entrenadores,
                            username = e.username,
                            fullname = e.fullname,
                            email = e.email,
                            userPass = e.userPass
                        };
                    }
                }
                return entrenadores;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }

        public bool Create(Entrenadore entrenador)
        {
            bool respuesta = false;
            try
            {
                entities.Entrenadores.Add(entrenador);
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
                Entrenadore entrenador = entities.Entrenadores.Where(p => p.ID_Entrenadores == id).First();
                entities.Entrenadores.Remove(entrenador);
                entities.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return respuesta;
        }

        public bool Update(Entrenadore entrenadore)
        {
            bool respuesta = false;
            try
            {
                var entrenador = entities.Entrenadores.Where(p => p.ID_Entrenadores == entrenadore.ID_Entrenadores).First();
                entrenador.username = entrenadore.username;
                entrenador.fullname = entrenadore.fullname;
                entrenador.email = entrenadore.email;
                entrenador.userPass = entrenadore.userPass;

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
