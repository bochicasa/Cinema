using Cine.API;
using Microsoft.Extensions.Configuration;

namespace Integration.Test.Reserva
{
    class ReservaSetup : Startup
    {
        public ReservaSetup(IConfiguration env) : base(env)
        {
        }
    }
}
