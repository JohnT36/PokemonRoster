using PokemonRoster.Models;
using System.Data;
using Dapper;



namespace PokemonRoster.Data
   
{
    public class PokeRepository : IPokeRepository
    {
        private readonly IDbConnection _conn;
        public PokeRepository(IDbConnection conn) 
        {
            _conn = conn;
        }        

        public void AddToRoster(UserPokemon userResp)
        {
            _conn.Execute("INSERT INTO roster (name, id, sprite) VALUES (@name, @id, @sprite);",
                 new { name = userResp.name, id = userResp.id, sprite = userResp.sprite });
        } 
        
        public void AddToPokedex(UserPokemon pokemon)
        {
            _conn.Execute("INSERT INTO pokedex (name, id, sprite) VALUES (@name, @id, @sprite);",
                 new { name = pokemon.name, id = pokemon.id, sprite = pokemon.sprite });
        }

        public IEnumerable<UserPokemon> GetRosterPokemon()
        {
            return _conn.Query<UserPokemon>("SELECT * FROM roster Order By id ASC;");
        }        

        public void RemoveFromRoster(string pokemonToRemove)
        {
            _conn.Execute("Delete From roster where name = @name", new { name = pokemonToRemove, });
        }

        public void AddToPokedexAllPokemonOneTime(IEnumerable<UserPokemon> pokedex)
        {
            for(var x = 0;x<=pokedex.Count()-1;x++)
            {
                AddToPokedex(pokedex.ElementAt(x));
            }
        }

        public void AddToFavs(UserPokemon userResp)
        {   
            _conn.Execute("Insert into favs (name, id, sprite, nickname) Values (@name, @id, @sprite, @nickname);",
                new { name = userResp.name, id = userResp.id, sprite = userResp.sprite, nickname = userResp.nickname });
        }
        public IEnumerable<UserPokemon> GetFavsPokemon()
        {
            throw new NotImplementedException();
        }
        public void RemoveFromFavs(string pokemonToRemove)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserPokemon> GetPokedexPokemon()
        {
            return _conn.Query<UserPokemon>("SELECT * FROM pokedex Order By id ASC;");
        }
    }
}
