using Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    /*
     
    ..:: PokemonService ::..
    - Realiza todas las operaciones con la entidad Pokedex.
     
     */
    public class PokemonService
    {
        PokemonEntities entities = new PokemonEntities();

        public List<Pokedex> Get()
        {
            try
            {
                List<Pokedex> pokedexes = entities.Pokedexes.ToList();
                return pokedexes;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }

        public List<Pokedex> Get(string nombre)
        {
            try
            {
                List<Pokedex> pokemones = new List<Pokedex>();
                foreach (Pokedex c in entities.Pokedexes.ToList())
                {
                    if (c.nombrePokemon.ToLower().Contains(nombre.ToLower()))
                    {
                        Pokedex pokemon = new Pokedex
                        {
                            ID_Pokedex = c.ID_Pokedex,
                            nombrePokemon = c.nombrePokemon,
                            alturaMetros = c.alturaMetros,
                            categoria = c.categoria,
                            pesoKg = c.pesoKg,
                            habilidad = c.habilidad,
                            sexo = c.sexo,
                            tipo = c.tipo,
                            debilidad = c.debilidad
                        };
                        pokemones.Add(pokemon);
                    }
                }
                return pokemones;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }

        public Pokedex GetOnlyOne(string nombre)
        {
            try
            {
                Pokedex pokedex = entities.Pokedexes.Where(p => p.nombrePokemon == nombre).First();
                return pokedex;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }

        public List<Pokedex> Get(int id)
        {
            try
            {
                List<Pokedex> pokemones = new List<Pokedex>();
                foreach (Pokedex c in entities.Pokedexes.ToList())
                {
                    if (c.ID_Pokedex.ToString().Contains(id.ToString()))
                    {
                        Pokedex pokemon = new Pokedex
                        {
                            ID_Pokedex = c.ID_Pokedex,
                            nombrePokemon = c.nombrePokemon,
                            alturaMetros = c.alturaMetros,
                            categoria = c.categoria,
                            pesoKg = c.pesoKg,
                            habilidad = c.habilidad,
                            sexo = c.sexo,
                            tipo = c.tipo,
                            debilidad = c.debilidad
                        };
                        pokemones.Add(pokemon);
                    }
                }
                return pokemones;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }

        public Pokedex GetOnlyOne(int id)
        {
            try
            {
                Pokedex pokedex = entities.Pokedexes.Where(p => p.ID_Pokedex == id).First();
                return pokedex;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }
    }
}
