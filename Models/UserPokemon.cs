namespace PokemonRoster.Models
{
    public class UserPokemon
    {
        public List<string> abilities { get; set; }

        public int height { get; set; }

        public int id { get; set; }

        public List<string> moves { get; set; }

        public string? name { get; set; }

        public string sprite { get; set; }

        public string spriteDW { get; set; }
        public List<int> stats { get; set; }
        public List<string>? types { get; set; }
        public int weight { get; set; }
        public string nickname { get; set; }
        public List<string> strengths { get; set; }
        public List<string> weaknesses { get; set; }
        public string backgroundcolorbytype { get; set; }
    }
}
