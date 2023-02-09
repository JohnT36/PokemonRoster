using PokemonRoster.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace PokemonRoster.Client
{
    public class PokeClient : IPokeClient
    {
        private readonly HttpClient _conn = new HttpClient();        

        public Pokemon? GetPokemonByName(string pokemonName)
        {
            try
            {
                var pokeResponse = _conn.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonName.ToLower()}").Result;
            }
             catch
            {
                return null;
            }
            var pokeResponsee = _conn.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonName.ToLower()}").Result;
            var pokemonInfo = JsonSerializer.Deserialize<PokemonApiObj>(pokeResponsee);
                var pokemon = new Pokemon()
                {
                    name = pokemonInfo.name,
                    abilities = pokemonInfo.abilities.Select(ability => ability.ability.name).ToList(),
                    height = pokemonInfo.height,
                    id = pokemonInfo.id,
                    moves = pokemonInfo.moves.Select(move => move.move.name).ToList(),
                    sprite = pokemonInfo.sprites.front_default,
                    stats = pokemonInfo.stats.Select(stat => stat.base_stat).ToList(),
                    types = pokemonInfo.types.Select(type => type.type.name).ToList(),
                    weight = pokemonInfo.weight,

                };
                return pokemon;
            

        }       

        public IEnumerable<Pokemon> GetGroupOfPokemonFromPokemon (Pokemon ok)
        {
            var groupPoke = new List<Pokemon>();
            var negCount = ok.id;
            var posCount = ok.id;
            groupPoke.Add(ok);

            if (negCount > 1 && negCount != 0)
            {
                negCount--;
                var poke1 = GetPokemonByID(negCount);
                groupPoke.Add(poke1);
            }

            if (negCount > 1 && negCount != 0)
            {
                negCount--;
                var poke2 = GetPokemonByID(negCount);
                groupPoke.Add(poke2);
            }

            if (posCount != 1008)
            {
                posCount++;
                var poke3 = GetPokemonByID(posCount);
                groupPoke.Add(poke3);
            }

            if (posCount != 1008)
            {
                posCount++;
                var poke4 = GetPokemonByID(posCount);
                groupPoke.Add(poke4);
            }


            return groupPoke;
        }

        public Pokemon? GetPokemonByID(int pokemonID)
        {
            try
            {
                var pokeResponse = _conn.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonID}").Result;
            }
            catch
            {
                return null;
            }
            var pokeResponsee = _conn.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonID}").Result;
            var pokemonInfo = JsonSerializer.Deserialize<PokemonApiObj>(pokeResponsee);
                var pokemon = new Pokemon()
                {
                    name = pokemonInfo.name,
                    abilities = pokemonInfo.abilities.Select(ability => ability.ability.name).ToList(),
                    height = pokemonInfo.height,
                    id = pokemonInfo.id,
                    moves = pokemonInfo.moves.Select(move => move.move.name).ToList(),
                    sprite = pokemonInfo.sprites.front_default,
                    spriteDW = pokemonInfo.sprites.other.dream_world.front_default,
                    stats = pokemonInfo.stats.Select(stat => stat.base_stat).ToList(),
                    types = pokemonInfo.types.Select(type => type.type.name).ToList(),
                    weight = pokemonInfo.weight,

                };
                return pokemon;
         
            
            
        }

        public PokemonApiObj GetPokemonForInfo(string pokemonName)
        {
            var pokeResponse = _conn.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonName}").Result;
            var pokemonInfo = JsonSerializer.Deserialize<PokemonApiObj>(pokeResponse);

            return pokemonInfo;
        }

        public IEnumerable<Pokemon> GetAllPokemonInThePokedex()
        {
            var pokedex = new List<Pokemon>();
            for(var x = 801;x<=1008;x++)
            {
                var pokemonSingle = GetPokemonByID(x);
                pokedex.Add(pokemonSingle);

            }
            return pokedex;
        }
    }
}
