using System.Collections.Generic;

namespace Cine.View.Services.ModelDtos
{
    public partial class ClienteDto
    {
        public decimal SecCli { get; set; }
        public decimal Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }

        public virtual ICollection<BoletaDto> Boleta { get; set; }
        public virtual ICollection<ReservaDto> Reserva { get; set; }
        public virtual ICollection<VentaDto> Venta { get; set; }
    }
}
