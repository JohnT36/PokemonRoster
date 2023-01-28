using Microsoft.AspNetCore.Mvc;
using PokemonRoster.Client;
using PokemonRoster.Data;
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
            var pResponse = Request.Form["pokemon"];
            var pokemon = _client.GetPokemon(pResponse);
            return View(pokemon);
        }

        public IActionResult AddToRoster()
        {
            var pokeName = Request.Form["pokemonName"];
            var pokemonObject = _client.GetPokemon(pokeName);
            _conn.AddToRoster(pokemonObject);
            return RedirectToAction("Roster");
        }

        public IActionResult Roster()
        {
           var pokemons = _conn.GetPokemons();
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
    }
}
