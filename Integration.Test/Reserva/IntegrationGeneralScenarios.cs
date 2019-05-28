using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Integration.Test.Reserva
{
    public class IntegrationGeneralScenarios
    {

        [Fact]
        public async Task RetunCostoSillas()
        {
            var funcionId = 1;
            using (var reservaServer = new ReservaTestBase().CreateServer())
            {
                var reservaClient = reservaServer.CreateClient();
                var url = $"/CineApi/api/Reserva/costo/{funcionId}";
                var response = await reservaClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
