using System.Collections.Generic;

namespace PokemonApi.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Types { get; set; }
        public int Generation { get; set; }
        public int? NextEvolutionId { get; set; }
        public int? BaseEvolutionId { get; set; }
        public string ImageUrl { get; set; }
    }
}