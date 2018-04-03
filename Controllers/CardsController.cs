using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netcore.webapi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace netcore.webapi.Controllers
{
    [Route("api/[controller]")]
    public class CardsController : Controller
    {
        [HttpGet("Random")]
        public async Task<IActionResult> GetRandomCardAsync()
        {
            Random random = new Random();
            int randomId = random.Next(1, 4980);

            var card = new Card();
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.magicthegathering.io/v1/cards/");
            client.DefaultRequestHeaders.Accept.Clear();
            var response = await client.GetAsync(randomId.ToString());
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                card = JObject.Parse(stringResponse)["card"].ToObject<Card>();
                return Ok(card);
            }
            else
                return NotFound();            
        }

        [HttpGet("ByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var card = new Card();
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.magicthegathering.io/v1/");
            client.DefaultRequestHeaders.Accept.Clear();
            var response = await client.GetAsync("cards?name=" + name);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                if(JObject.Parse(stringResponse)["cards"].Count() > 0)
                    card = JObject.Parse(stringResponse)["cards"][0].ToObject<Card>();                
                else
                    return Json(null);
                return Ok(card);
            }
            else
                return NotFound();
        }
    }
}