using PokemonRoster.Models;

namespace PokemonRoster.Data
{
    public interface IPokeRepository
    {
        public void AddToRoster(Pokemon userResp);
        public void RemoveFromRoster(string pokemonToRemove);
        public IEnumerable<Pokemon> GetPokemons();
        
    }
}
