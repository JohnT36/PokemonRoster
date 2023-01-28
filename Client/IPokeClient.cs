using PokemonRoster.Models;

namespace PokemonRoster.Client
{
    public interface IPokeClient
    {
        public Pokemon GetPokemon(string pokemonName);
    }
}
