using System;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest/";
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            Console.WriteLine("Good evening everyone. Today we have two special guests. Kanye West and Ron Swanson");
            Console.WriteLine("They're going to be discussing life... and whatever else may come up. ");
            Console.WriteLine("Kanye, would you care to kick things off?");
            Console.WriteLine("------------------------ *Kanye looks directly into the camera*");
            Console.WriteLine("                                                               ");
            for (int i = 0; i < 10; i++)
            {
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                Console.WriteLine($"Kanye: {kanyeQuote}");
                Console.WriteLine("                    ");

                var ronResponse = client.GetStringAsync(ronURL).Result;
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                Console.WriteLine($"Ron: {ronQuote}");
                Console.WriteLine("                    ");
            }
        }
    }
}