namespace PokemonRoster.Models
{
    public class Pokemon
    {
        public List<string> abilities { get; set; }

        public int height { get; set; }

        public int id { get; set; }

        public List<string> moves { get; set; }

        public string? name { get; set; }

        public string sprite { get; set; }
        public List<int> stats { get; set; }
        public List<string>? types { get; set; }
        public int weight { get; set; }
    }
}
