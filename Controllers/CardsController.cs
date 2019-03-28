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
using Microsoft.Extensions.Configuration;

namespace netcore.webapi.Controllers
{
    [Route("api/[controller]")]
    public class CardsController : Controller
    {
        private IConfiguration _configuration;

        public CardsController(IConfiguration configuration)
        {
            _configuration=configuration;
        }

        [HttpGet("Random")]
        public async Task<IActionResult> GetRandomCardAsync()
        {
            //move to serviceLayer
            var gameTypes = _configuration.GetSection("GameTypes").Get<string[]>();

            Random random = new Random();
            int randomId = random.Next(1, 4980);

            var card = new Card();
            var client = new HttpClient();
            var apiUrl = _configuration?.GetSection("MySettings")?.GetSection("ApiURL")?.Value;
            client.BaseAddress = new Uri(apiUrl+"cards/");
            client.DefaultRequestHeaders.Accept.Clear();
            var response = await client.GetAsync(randomId.ToString());
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                card = JObject.Parse(stringResponse)["card"].ToObject<Card>();                
                //move to serviceLayer
                if(card.Legalities!=null)
                {
                    var cardGameTypes = card.Legalities.Where(le=>le.legality=="Legal").Select(le=>le.format).ToList();
                    card.GameLegal = gameTypes.Where(gt=>cardGameTypes.Contains(gt)).ToArray();
                    card.GameIlegal = gameTypes.Where(gt=>!cardGameTypes.Contains(gt)).ToArray();
                }
                return Ok(new List<Card> { card });
            }
            else
                return NotFound();            
        }

        [HttpGet("ByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            //TODO: move to serviceLayer
            var gameTypes = _configuration.GetSection("GameTypes").Get<string[]>();
            var result = new List<Card>();
            var client = new HttpClient();
            var apiUrl = _configuration?.GetSection("MySettings")?.GetSection("ApiURL")?.Value;
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            var response = await client.GetAsync("cards?name=" + name);            
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                JObject cardSearch = JObject.Parse(stringResponse);
                //Serialize
                IList<JToken> searchResult = cardSearch["cards"].Children().ToList();                
                if (searchResult.Count() > 0)
                {                   
                    foreach(JToken itemCard in searchResult)
                    {
                        Card card = itemCard.ToObject<Card>();
                        if(card.Legalities!=null)
                        {
                            var cardGameTypes = card.Legalities.Where(le=>le.legality=="Legal").Select(le=>le.format).ToList();
                            card.GameLegal = gameTypes.Where(gt=>cardGameTypes.Contains(gt)).ToArray();
                            card.GameIlegal = gameTypes.Where(gt=>!cardGameTypes.Contains(gt)).ToArray();
                        }
                        result.Add(card);
                    }
                    
                }else
                    return Json(null);
                return Ok(result);
            }
            else
                return NotFound();
        }

        [HttpGet("ListByName/{name}")]
        public async Task<IActionResult> ListByName(string name)
        {
            //TODO: move to serviceLayer
            var result = new List<CardRow>();
            var client = new HttpClient();
            var apiUrl = _configuration?.GetSection("MySettings")?.GetSection("ApiURL")?.Value;
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            var response = await client.GetAsync("cards?name=" + name);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();                        
                JObject cardSearch = JObject.Parse(stringResponse);
                //Serialize
                if(JObject.Parse(stringResponse)["cards"].Count() > 0)
                {
                    result = cardSearch["cards"].ToObject<List<CardRow>>();                    
                }else
                    return Json(null);
                
                return Ok(result);
            }else
                return NotFound();
        }
    }
}