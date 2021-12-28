using Hacker_News_API_2.Models;
using Newtonsoft.Json.Linq;

namespace Hacker_News_API_2
{
    public class Logic
    {
        /// <summary>
        /// Method to get 20 best news in News objects
        /// </summary>
        /// <param name="client"></param>
        /// <param name="response"></param>
        /// <param name="numberNews"></param>
        /// <returns></returns>
        public static async Task<News[]> getBestAsync(HttpClient client, string response, int numberNews)
        {
            var arrayNews = response.Replace("[", "").Replace("]", "").Split(",").ToArray().Take(numberNews);

            var myNews = new News[20];
            int index = 0;
            foreach (var item in arrayNews)
            {
                var report = await client.GetStringAsync("https://hacker-news.firebaseio.com/v0/item/" + item + ".json");
                dynamic data = JObject.Parse(report);
                var news = new News();
                news.Id = Convert.ToInt32(item);
                news.Title = data.title;
                news.Uri = data.url;
                news.PostedBy = data.by;
                news.Time = DateTimeOffset.UtcNow;
                news.Score = data.score;
                news.CommentsCount = data.kids.Count;
                myNews[index] = news;
                index++;
            }
            return myNews;
        }
    }
}
