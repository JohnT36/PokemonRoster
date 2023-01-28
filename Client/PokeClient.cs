using PokemonRoster.Models;
using System.Text.Json;

namespace PokemonRoster.Client
{
    public class PokeClient : IPokeClient
    {
        HttpClient _conn = new HttpClient();
        public PokeClient()
        {

        }

        public Pokemon GetPokemon(string pokemonName)
        {
            var pokeResponse = _conn.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonName}").Result;
            var pokemonObj = JsonSerializer.Deserialize<PokemonApiResponse>(pokeResponse);
            var pokemon = new Pokemon()
            {
                name = pokemonObj.name,
                abilities = pokemonObj.abilities.Select(ability => ability.ability.name).ToList(),
                height = pokemonObj.height,
                id = pokemonObj.id,
                moves = pokemonObj.moves.Select(move => move.move.name).ToList(),
                sprite = pokemonObj.sprites.front_default,
                stats = pokemonObj.stats.Select(stat => stat.base_stat).ToList(),
                types = pokemonObj.types.Select(type => type.type.name).ToList(),
                weight = pokemonObj.weight,

            };
            return pokemon;

        }





    }
}
