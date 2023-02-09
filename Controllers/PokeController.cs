using Microsoft.AspNetCore.Mvc;
using PokemonRoster.Client;
using PokemonRoster.Data;
using PokemonRoster.Models;
using System.Runtime.InteropServices;

namespace PokemonRoster.Controllers
{
    public class PokeController : Controller
    {
        private readonly IPokeClient _client;
        private readonly IPokeRepository _conn;
        public PokeController(IPokeClient client, IPokeRepository conn)
        {
            _client = client;
            _conn = conn;
        }
        public IActionResult Index()
        {
            var userResponse = Request.Form["pokemon"];            
            bool isDigit = false;
            foreach(char p in userResponse.ToString())
            {
                if (Char.IsDigit(p))
                {
                    isDigit = true;
                    

                }
            }

            if (isDigit)
            {
                var pokemon = _client.GetPokemonByID(int.Parse(userResponse));
                if (pokemon == null)
                {
                    ErrorModel model = new ErrorModel()
                    {
                        UserInput = userResponse,
                    };
                    return RedirectToAction("Error", model);
                }
                var pokemons = _client.GetGroupOfPokemonFromPokemon(pokemon);
                return View(pokemons);
            }
            else
            {
                 var pokemon = _client.GetPokemonByName(userResponse);
                if (pokemon == null)
                {
                    ErrorModel model = new ErrorModel()
                    {
                        UserInput = userResponse,
                    };
                    return RedirectToAction("Error", model);
                }
                var pokemons = _client.GetGroupOfPokemonFromPokemon(pokemon);
                return View(pokemons);
            }
            
            
            
        }

        public IActionResult AddToRoster()
        {
            var pokeName = Request.Form["pokemonName"];
            var pokemonObject = _client.GetPokemonByName(pokeName);
            _conn.AddToRoster(pokemonObject);
            return RedirectToAction("Roster");
        }

        public IActionResult Roster()
        {
           var pokemons = _conn.GetRosterPokemon();
            if(pokemons.Count() <= 5 )
            {

            }
            return View(pokemons);
        }

        public IActionResult RemoveFromRoster()
        {
            var removePokemon = Request.Form["remove"];
            _conn.RemoveFromRoster(removePokemon);
            return RedirectToAction("Roster");

        }

        public IActionResult AddToFavs()
        {
            return RedirectToAction("Favs");
        }

        public IActionResult Favs() 
        {
            return View();
        }

        public IActionResult RemoveFromFavs()
        {
            return RedirectToAction("Favs");
        }

        public IActionResult Info()
        {
            var pResponse = Request.Form["pokemonName"];
            var pokemon = _client.GetPokemonForInfo(pResponse);
            return View(pokemon);

        }

        public IActionResult Pokedex()
        {
            var pokedex = _conn.GetPokedexPokemon();
            return View(pokedex);

        }

        public IActionResult Error(ErrorModel model)
        {

            return View(model);
        }
    }
}
