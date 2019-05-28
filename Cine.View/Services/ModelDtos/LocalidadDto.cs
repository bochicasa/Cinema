using System.Collections.Generic;

namespace Cine.View.Services.ModelDtos
{
    public partial class LocalidadDto
    {
        public decimal Id { get; set; }
        public decimal Sala { get; set; }
        public string Nombre { get; set; }
        public string Observaciones { get; set; }

        public virtual ICollection<BoletaDto> Boleta { get; set; }
        public virtual ICollection<ReservaDto> Reserva { get; set; }
        public virtual ICollection<SillaDto> Silla { get; set; }

    }
}
