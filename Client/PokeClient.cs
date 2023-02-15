using PokemonRoster.Models;
using PokemonRoster.Models.PokemonType;
using System.Collections.Generic;
using System.Text.Json;

namespace PokemonRoster.Client
{
    public class PokeClient : IPokeClient
    {
        private readonly HttpClient _conn = new HttpClient();        

        public UserPokemon? GetPokemonByName(string pokemonName)
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
            
                var pokeResponseType = _conn.GetStringAsync($"{pokemonInfo.types[0].type.url}").Result;
            var pokemonInfoType = JsonSerializer.Deserialize<PokemonTypes>(pokeResponseType);


            var pokemon = new UserPokemon()
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
                weaknesses = pokemonInfoType.damage_relations.double_damage_from.Select(x => x.name).ToList(),
                strengths = pokemonInfoType.damage_relations.double_damage_to.Select(x => x.name).ToList(),


        };

            return pokemon;

        }       

        public IEnumerable<UserPokemon> GetGroupOfPokemonFromPokemon (UserPokemon ok)
        {
            var groupPoke = new List<UserPokemon>();
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

        public UserPokemon? GetPokemonByID(int pokemonID)
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

            var pokeResponseType = _conn.GetStringAsync($"{pokemonInfo.types[0].type.url}").Result;
            var pokemonInfoType = JsonSerializer.Deserialize<PokemonTypes>(pokeResponseType);

            var pokemon = new UserPokemon()
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
                weaknesses = pokemonInfoType.damage_relations.double_damage_from.Select(x => x.name).ToList(),
                strengths = pokemonInfoType.damage_relations.double_damage_to.Select(x => x.name).ToList(),

            };
            switch(pokemon.types[0].ToLower())
            {
                case "fire": pokemon.backgroundcolorbytype = "red"; break;
                case "water": pokemon.backgroundcolorbytype = "blue"; break;
                case "grass": pokemon.backgroundcolorbytype = "green"; break;
                case "normal": pokemon.backgroundcolorbytype = "gray"; break;
                case "flying": pokemon.backgroundcolorbytype = "white"; break;
                case "fighting": pokemon.backgroundcolorbytype = "orange"; break;
                case "poison": pokemon.backgroundcolorbytype = "purple"; break;
                case "electric": pokemon.backgroundcolorbytype = "yellow"; break;
                case "ground": pokemon.backgroundcolorbytype = "brown"; break;
                case "rock": pokemon.backgroundcolorbytype = "brown"; break;
                case "ice": pokemon.backgroundcolorbytype = "blue"; break;
                case "bug": pokemon.backgroundcolorbytype = "green"; break;
                case "ghoes": pokemon.backgroundcolorbytype = "pruple"; break;
                case "steel": pokemon.backgroundcolorbytype = "sliver"; break;
                case "dragon": pokemon.backgroundcolorbytype = "purple"; break;
                case "fairy": pokemon.backgroundcolorbytype = "pink"; break;                
                

            }
                return pokemon;
         
            
            
        }

        public PokemonApiObj GetPokemonForInfo(string pokemonName)
        {
            var pokeResponse = _conn.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonName}").Result;
            var pokemonInfo = JsonSerializer.Deserialize<PokemonApiObj>(pokeResponse);

            return pokemonInfo;
        }

        public IEnumerable<UserPokemon> GetAllPokemonInThePokedex()
        {
            var pokedex = new List<UserPokemon>();
            for(var x = 801;x<=1008;x++)
            {
                var pokemonSingle = GetPokemonByID(x);
                pokedex.Add(pokemonSingle);

            }
            return pokedex;
        }
    }
}
