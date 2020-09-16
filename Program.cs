using System;
using System.Net;
using System.Timers;
using TweetSharp;


namespace TwitterBot
{
    class Program
    {
        private static string customer_key = "NnhkplNzgDYYgD36WjMEqGApO";
        private static string customer_key_secret = "V0KW7ZNIfeUJnBRHaYMSQzYRGkKOq1nSvx0JvjMCPnyiCCsj35";
        private static string access_token = "1715594070-j25nA4IHw4HBAPtX2QGQk6BvevpK8S1lY41mxK6";
        private static string access_token_secret = "joQ6hiInmeORlLS2dhUMQ7Q4okDsLnl4BbX8mXsEJB9yY";

        private static TwitterService service = new TwitterService(customer_key, customer_key_secret, access_token, access_token_secret);

        static void Main(string[] args)
        {
            Console.WriteLine($"<{DateTime.Now}> - Bot Started");
            Console.WriteLine("What you want to tweet:");
            string twe = Console.ReadLine();
            SendTweet(twe);
            Console.WriteLine("Tweet Sent!");
            Console.Read();
        }

        private static void SendTweet(string _status)
        {
            _ = service.SendTweet(new SendTweetOptions { Status = _status }, (tweet, response) =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"<ERROR>" + response.Error.Message);
                        Console.ResetColor();
                    }
                });
        }
    }
}
