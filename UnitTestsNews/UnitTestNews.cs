using Hacker_News_API_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UnitTestsNews
{
    [TestClass]
    public class UnitTestNews
    {
        [TestMethod]
        public async Task TestGetAsync()
        {
            var newsController = new Hacker_News_API_2.Controllers.NewsController();
            Assert.IsNotNull(newsController.GetAsync());
        }

        [TestMethod]
        public async Task TestGetBest20Async()
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/beststories.json") };
            var response = await client.GetStringAsync("https://hacker-news.firebaseio.com/v0/beststories.json");
            var newsController = new Hacker_News_API_2.Controllers.NewsController();
            Assert.IsNotNull(newsController.GetAsync20());
            Assert.AreEqual(20, Logic.getBestAsync(client, response, 20).Result.Length);
        }
    }
}
