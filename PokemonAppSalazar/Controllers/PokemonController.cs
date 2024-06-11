using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

//something something

namespace PokemonAppSalazar.Controllers
{
    public class PokemonController : Controller
    {
        private readonly HttpClient _httpClient;

        public PokemonController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new System.Uri("https://pokeapi.co/api/v2/");
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var response = await _httpClient.GetAsync($"pokemon?offset={(page - 1) * 20}&limit=20");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var pokemonList = JsonConvert.DeserializeObject<PokemonList>(json);
                return View(pokemonList);
            }
            else
            {
                // Handle error
                return View("Error");
            }
        }

        public async Task<IActionResult> Details(string name)
        {
            var response = await _httpClient.GetAsync($"pokemon/{name.ToLower()}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var pokemon = JsonConvert.DeserializeObject<Pokemon>(json);
                return View(pokemon);
            }
            else
            {
                // Handle error
                return View("Error");
            }
        }
    }

    public class PokemonList
    {
        public List<PokemonListItem> Results { get; set; }
    }

    public class PokemonListItem
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Pokemon
    {
        public string Name { get; set; }
        public List<PokemonMove> Moves { get; set; }
        public List<AbilityEntry> Abilities { get; set; }
    }

    public class AbilityEntry
    {
        public Ability Ability { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
    }

    public class Ability
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class PokemonMove
    {
        public Move Move { get; set; }
        public List<VersionGroupDetail> VersionGroupDetails { get; set; }
    }

    public class Move
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class VersionGroupDetail
    {
        public int LevelLearnedAt { get; set; }
        public MoveLearnMethod MoveLearnMethod { get; set; }
        public VersionGroup VersionGroup { get; set; }
    }

    public class MoveLearnMethod
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class VersionGroup
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
