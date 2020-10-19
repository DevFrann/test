using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace ClientCredentials
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                using (var timer = new System.Timers.Timer(20000))
                {
                    try
                    {
                        timer.Elapsed += async (sender, e) =>
                        {
                            try
                            {
                                var content = await client.GetAsync("http://localhost:64127/Customers/");
                                var result = await content.Content.ReadAsStringAsync();
                                Console.WriteLine(result);
                            }
                            catch (AuthenticationException)
                            {

                            }
                        };

                        timer.Start();

                        Console.ReadLine();
                    }
                    catch (AuthenticationException)
                    {

                    }
                }
            }
        }
    }
}
