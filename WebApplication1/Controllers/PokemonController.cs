using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonDataService _pokemonService;

        public PokemonController(PokemonDataService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(_pokemonService.GetPaginatedPokemons(page, pageSize));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pokemon = _pokemonService.GetPokemonById(id);
            return pokemon == null ? NotFound() : Ok(pokemon);
        }

        [HttpGet("generation/{generation}")]
        public IActionResult GetByGeneration(int generation, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(_pokemonService.GetPokemonsByGeneration(generation)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList());
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var pokemon = _pokemonService.GetAllPokemons()
                .FirstOrDefault(p => p.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));

            if (pokemon == null)
            {
                return NotFound($"Pokémon with name '{name}' not found");
            }

            // Handle nullable evolution IDs
            Pokemon nextEvolution = null;
            if (pokemon.NextEvolutionId.HasValue)
            {
                nextEvolution = _pokemonService.GetPokemonById(pokemon.NextEvolutionId.Value);
            }

            Pokemon baseEvolution = null;
            if (pokemon.BaseEvolutionId.HasValue)
            {
                baseEvolution = _pokemonService.GetPokemonById(pokemon.BaseEvolutionId.Value);
            }

            return Ok(new
            {
                pokemon.Id,
                pokemon.Name,
                pokemon.Types,
                Height = pokemon.Height / 10.0,  // Convert to meters
                Weight = pokemon.Weight / 10.0,  // Convert to kg
                pokemon.ImageUrl,
                Generation = pokemon.Generation,
                Evolutions = new
                {
                    Next = nextEvolution != null ? new
                    {
                        nextEvolution.Id,
                        nextEvolution.Name,
                        nextEvolution.ImageUrl
                    } : null,
                    Base = baseEvolution != null ? new
                    {
                        baseEvolution.Id,
                        baseEvolution.Name,
                        baseEvolution.ImageUrl
                    } : null
                }
            });
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string term, [FromQuery] int limit = 10)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return BadRequest("Search term cannot be empty");
            }

            var results = _pokemonService.GetAllPokemons()
                .Where(p => p.Name.Contains(term, System.StringComparison.OrdinalIgnoreCase))
                .Take(limit)
                .Select(p => new {
                    p.Id,
                    p.Name,
                    p.ImageUrl
                })
                .ToList();

            return Ok(results);
        }
    }
}