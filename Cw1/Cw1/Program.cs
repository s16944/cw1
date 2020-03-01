using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

namespace Cw1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var result = await client.GetAsync("https://www.pja.edu.pl");

            if (result.IsSuccessStatusCode)
            {
                var html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);
                var matches = regex.Matches(html);
                foreach (var mail in matches)
                {
                    Console.WriteLine(mail);
                }
            }

            Console.WriteLine("Hello World!");
        }
    }
}