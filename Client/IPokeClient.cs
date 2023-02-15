using PokemonRoster.Models;

namespace PokemonRoster.Client
{
    public interface IPokeClient
    {
        public UserPokemon? GetPokemonByName(string pokemonName);
        public UserPokemon? GetPokemonByID(int id);
        public IEnumerable<UserPokemon> GetGroupOfPokemonFromPokemon(UserPokemon pokemon);
        public PokemonApiObj GetPokemonForInfo(string pokemonName);
        public IEnumerable<UserPokemon> GetAllPokemonInThePokedex();
    }
}
