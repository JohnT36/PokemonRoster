using PokemonRoster.Models;

namespace PokemonRoster.Data
{
    public interface IPokeRepository
    {
        public void AddToRoster(Pokemon userResp);
        public void RemoveFromRoster(string pokemonToRemove);
        public IEnumerable<Pokemon> GetRosterPokemon();
        public void AddToFavs(Pokemon userResp);
        public IEnumerable<Pokemon> GetFavsPokemon();
        public void RemoveFromFavs(string pokemonToRemove);
        public void AddToPokedexAllPokemonOneTime(IEnumerable<Pokemon> pokemon);
        public IEnumerable<Pokemon> GetPokedexPokemon();


    }
}
