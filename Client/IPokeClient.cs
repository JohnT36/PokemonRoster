using PokemonRoster.Models;

namespace PokemonRoster.Client
{
    public interface IPokeClient
    {
        public Pokemon GetPokemonByName(string pokemonName);
        public Pokemon GetPokemonByID(int id);
        public IEnumerable<Pokemon> GetGroupOfPokemonFromPokemon(Pokemon pokemon);
        public PokemonApiObj GetPokemonForInfo(string pokemonName);
        public IEnumerable<Pokemon> GetAllPokemonInThePokedex();
    }
}
