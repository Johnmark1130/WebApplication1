using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Services
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

        public List<Pokemon> GetPaginatedPokemons(int page, int pageSize) =>
            _pokemons.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        private List<Pokemon> GeneratePokemonData()
        {
            return new List<Pokemon>
            {
                // Generation 1 - Bulbasaur Line
                new Pokemon {
                    Id = 1, Name = "Bulbasaur", Types = new List<string> { "Grass", "Poison" },
                    Generation = 1, NextEvolutionId = 2, BaseEvolutionId = null,
                    ImageUrl = "https://img.pokemondb.net/artwork/bulbasaur.jpg",
                    Height = 7, Weight = 69
                },
                new Pokemon {
                    Id = 2, Name = "Ivysaur", Types = new List<string> { "Grass", "Poison" },
                    Generation = 1, NextEvolutionId = 3, BaseEvolutionId = 1,
                    ImageUrl = "https://img.pokemondb.net/artwork/ivysaur.jpg",
                    Height = 10, Weight = 130
                },
                new Pokemon {
                    Id = 3, Name = "Venusaur", Types = new List<string> { "Grass", "Poison" },
                    Generation = 1, NextEvolutionId = null, BaseEvolutionId = 1,
                    ImageUrl = "https://img.pokemondb.net/artwork/venusaur.jpg",
                    Height = 20, Weight = 1000
                },

                // Generation 1 - Charmander Line
                new Pokemon {
                    Id = 4, Name = "Charmander", Types = new List<string> { "Fire" },
                    Generation = 1, NextEvolutionId = 5, BaseEvolutionId = null,
                    ImageUrl = "https://img.pokemondb.net/artwork/charmander.jpg",
                    Height = 6, Weight = 85
                },
                new Pokemon {
                    Id = 5, Name = "Charmeleon", Types = new List<string> { "Fire" },
                    Generation = 1, NextEvolutionId = 6, BaseEvolutionId = 4,
                    ImageUrl = "https://img.pokemondb.net/artwork/charmeleon.jpg",
                    Height = 11, Weight = 190
                },
                new Pokemon {
                    Id = 6, Name = "Charizard", Types = new List<string> { "Fire", "Flying" },
                    Generation = 1, NextEvolutionId = null, BaseEvolutionId = 4,
                    ImageUrl = "https://img.pokemondb.net/artwork/charizard.jpg",
                    Height = 17, Weight = 905
                },

                // Generation 1 - Squirtle Line
                new Pokemon {
                    Id = 7, Name = "Squirtle", Types = new List<string> { "Water" },
                    Generation = 1, NextEvolutionId = 8, BaseEvolutionId = null,
                    ImageUrl = "https://img.pokemondb.net/artwork/squirtle.jpg",
                    Height = 5, Weight = 90
                },
                new Pokemon {
                    Id = 8, Name = "Wartortle", Types = new List<string> { "Water" },
                    Generation = 1, NextEvolutionId = 9, BaseEvolutionId = 7,
                    ImageUrl = "https://img.pokemondb.net/artwork/wartortle.jpg",
                    Height = 10, Weight = 225
                },
                new Pokemon {
                    Id = 9, Name = "Blastoise", Types = new List<string> { "Water" },
                    Generation = 1, NextEvolutionId = null, BaseEvolutionId = 7,
                    ImageUrl = "https://img.pokemondb.net/artwork/blastoise.jpg",
                    Height = 16, Weight = 855
                },

                // Generation 2 - Chikorita Line
                new Pokemon {
                    Id = 152, Name = "Chikorita", Types = new List<string> { "Grass" },
                    Generation = 2, NextEvolutionId = 153, BaseEvolutionId = null,
                    ImageUrl = "https://img.pokemondb.net/artwork/chikorita.jpg",
                    Height = 9, Weight = 64
                },
                new Pokemon {
                    Id = 153, Name = "Bayleef", Types = new List<string> { "Grass" },
                    Generation = 2, NextEvolutionId = 154, BaseEvolutionId = 152,
                    ImageUrl = "https://img.pokemondb.net/artwork/bayleef.jpg",
                    Height = 12, Weight = 158
                },
                new Pokemon {
                    Id = 154, Name = "Meganium", Types = new List<string> { "Grass" },
                    Generation = 2, NextEvolutionId = null, BaseEvolutionId = 152,
                    ImageUrl = "https://img.pokemondb.net/artwork/meganium.jpg",
                    Height = 18, Weight = 1005
                },
                 new Pokemon {
                    Id = 25, Name = "Pikachu", Types = new List<string> { "Electric" },
                    Generation = 1, NextEvolutionId = 26, BaseEvolutionId = 172,
                    ImageUrl = "https://img.pokemondb.net/artwork/pikachu.jpg",
                    Height = 4, Weight = 60
                 },
                new Pokemon {
                    Id = 26, Name = "Raichu", Types = new List<string> { "Electric" },
                    Generation = 1, NextEvolutionId = null, BaseEvolutionId = 25,
                    ImageUrl = "https://img.pokemondb.net/artwork/raichu.jpg",
                    Height = 8, Weight = 300
                },

                // Generation 1 - Geodude Line
                new Pokemon {
                    Id = 74, Name = "Geodude", Types = new List<string> { "Rock", "Ground" },
                    Generation = 1, NextEvolutionId = 75, BaseEvolutionId = null,
                    ImageUrl = "https://img.pokemondb.net/artwork/geodude.jpg",
                    Height = 4, Weight = 200
                },
                new Pokemon {
                    Id = 75, Name = "Graveler", Types = new List<string> { "Rock", "Ground" },
                    Generation = 1, NextEvolutionId = 76, BaseEvolutionId = 74,
                    ImageUrl = "https://img.pokemondb.net/artwork/graveler.jpg",
                    Height = 10, Weight = 1050
                },
        
                // Generation 1 - Abra Line
                new Pokemon {
                    Id = 63, Name = "Abra", Types = new List<string> { "Psychic" },
                    Generation = 1, NextEvolutionId = 64, BaseEvolutionId = null,
                    ImageUrl = "https://img.pokemondb.net/artwork/abra.jpg",
                    Height = 9, Weight = 195
                },
                new Pokemon {
                    Id = 64, Name = "Kadabra", Types = new List<string> { "Psychic" },
                    Generation = 1, NextEvolutionId = 65, BaseEvolutionId = 63,
                    ImageUrl = "https://img.pokemondb.net/artwork/kadabra.jpg",
                    Height = 13, Weight = 565
                },
        
                // Generation 2 - Cyndaquil Line
                new Pokemon {
                    Id = 155, Name = "Cyndaquil", Types = new List<string> { "Fire" },
                    Generation = 2, NextEvolutionId = 156, BaseEvolutionId = null,
                    ImageUrl = "https://img.pokemondb.net/artwork/cyndaquil.jpg",
                    Height = 5, Weight = 79
                },
                new Pokemon {
                    Id = 156, Name = "Quilava", Types = new List<string> { "Fire" },
                    Generation = 2, NextEvolutionId = 157, BaseEvolutionId = 155,
                    ImageUrl = "https://img.pokemondb.net/artwork/quilava.jpg",
                    Height = 9, Weight = 190
                },
        
                // Generation 2 - Totodile Line
                new Pokemon {
                    Id = 158, Name = "Totodile", Types = new List<string> { "Water" },
                    Generation = 2, NextEvolutionId = 159, BaseEvolutionId = null,
                    ImageUrl = "https://img.pokemondb.net/artwork/totodile.jpg",
                    Height = 6, Weight = 95
                },
                new Pokemon {
                    Id = 159, Name = "Croconaw", Types = new List<string> { "Water" },
                    Generation = 2, NextEvolutionId = 160, BaseEvolutionId = 158,
                    ImageUrl = "https://img.pokemondb.net/artwork/croconaw.jpg",
                    Height = 11, Weight = 250
                }

            };
        }
    }
}
