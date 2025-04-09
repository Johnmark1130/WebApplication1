using System.Collections.Generic;
namespace WebApplication1.Models
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
        public int Height { get; set; }  
        public int Weight { get; set; }  
    }
}
