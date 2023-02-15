using PokemonRoster.Models;

namespace PokemonRoster.Data
{
    public interface IPokeRepository
    {
        public void AddToRoster(UserPokemon userResp);
        public void RemoveFromRoster(string pokemonToRemove);
        public IEnumerable<UserPokemon> GetRosterPokemon();
        public void AddToFavs(UserPokemon userResp);
        public IEnumerable<UserPokemon> GetFavsPokemon();
        public void RemoveFromFavs(string pokemonToRemove);
        public void AddToPokedexAllPokemonOneTime(IEnumerable<UserPokemon> pokemon);
        public IEnumerable<UserPokemon> GetPokedexPokemon();


    }
}
