using System.IO;
using Microsoft.AspNetCore.Hosting;
using DownloadLib;

namespace WebScratchFactory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();


            string[] uris = new[] {
                "",
                "" };
            string destinationPath = "";
            DownloadHelper dh = new DownloadHelper(uris, destinationPath);
        }
    }
}
