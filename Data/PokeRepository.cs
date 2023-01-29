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

        

        public void AddToRoster(Pokemon userResp)
        {
            _conn.Execute("INSERT INTO roster (name, id, sprite) VALUES (@name, @id, @sprite);",
                 new { name = userResp.name, id = userResp.id, sprite = userResp.sprite });
        }      

        public IEnumerable<Pokemon> GetRosterPokemon()
        {
            return _conn.Query<Pokemon>("SELECT * FROM roster;");
        }        

        public void RemoveFromRoster(string pokemonToRemove)
        {
            _conn.Execute("Delete From roster where name = @name", new { name = pokemonToRemove, });
        }



        public void AddToFavs(Pokemon userResp)
        {   
            _conn.Execute("Insert into favs (name, id, sprite, nickname) Values (@name, @id, @sprite, @nickname);",
                new { name = userResp.name, id = userResp.id, sprite = userResp.sprite, nickname = userResp.nickname });
        }
        public IEnumerable<Pokemon> GetFavsPokemon()
        {
            throw new NotImplementedException();
        }
        public void RemoveFromFavs(string pokemonToRemove)
        {
            throw new NotImplementedException();
        }

    }
}
