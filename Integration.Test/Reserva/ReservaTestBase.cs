using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace Integration.Test.Reserva
{
    public class ReservaTestBase
    {
        public TestServer CreateServer()
        {
            var path = Assembly.GetAssembly(typeof(ReservaTestBase))
               .Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddJsonFile("appsettings.json", optional: false)
                    .AddEnvironmentVariables();
                }).UseStartup<ReservaSetup>();

            return new TestServer(hostBuilder);
        }

    }
}
