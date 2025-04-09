using PokemonApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PokemonApi.Services
{
    public class PokemonDataService
    {
        private readonly List<Pokemon> _pokemons;

        public PokemonDataService()
        {
            _pokemons = GeneratePokemonData();
        }

        public List<Pokemon> GetAllPokemons() => _pokemons;

        public Pokemon GetPokemonById(int id) => _pokemons.FirstOrDefault(p => p.Id == id);

        public List<Pokemon> GetPokemonsByGeneration(int generation) =>
            _pokemons.Where(p => p.Generation == generation).ToList();

        public List<Pokemon> GetPaginatedPokemons(int page, int pageSize)
        {
            return _pokemons
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        private List<Pokemon> GeneratePokemonData()
        {
            var pokemons = new List<Pokemon>
            {
             
                new Pokemon {
                    Id = 1, Name = "Bulbasaur", Types = new List<string> { "Grass", "Poison" },
                    Generation = 1, NextEvolutionId = 2, BaseEvolutionId = null,
                    ImageUrl = "https://img.pokemondb.net/artwork/bulbasaur.jpg"
                },
          
            };

            return pokemons;
        }
    }
}
