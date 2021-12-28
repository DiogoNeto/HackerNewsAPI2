using Hacker_News_API_2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Hacker_News_API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        // GET: /api/News
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                HttpClient client = new HttpClient { BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/beststories.json") };
                var response = await client.GetStringAsync("https://hacker-news.firebaseio.com/v0/beststories.json");
                return Ok(response);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERROR - " + ex.Message);
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("ERROR - " + ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // GET: /api/News/Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                HttpClient client = new HttpClient { BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/beststories.json") };
                var response = await client.GetStringAsync("https://hacker-news.firebaseio.com/v0/item/" + id + ".json");
                return Ok(response);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERROR - " + ex.Message);
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("ERROR - " + ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // GET: /best20
        [HttpGet]
        [Route("/best20")]
        public async Task<IActionResult> GetAsync20()
        {
            try
            {
                HttpClient client = new HttpClient { BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/beststories.json") };
                var response = await client.GetStringAsync("https://hacker-news.firebaseio.com/v0/beststories.json");
                News[] best20 = Logic.getBestAsync(client, response, 20).Result;
                string bestNews = JsonConvert.SerializeObject(best20);
                return Ok(bestNews);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERROR - " + ex.Message);
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("ERROR - " + ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - " + ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
