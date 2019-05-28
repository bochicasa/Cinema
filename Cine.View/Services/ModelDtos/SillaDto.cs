using System.Collections.Generic;

namespace Cine.View.Services.ModelDtos
{
    public partial class SillaDto
    {

        public decimal NumSil { get; set; }
        public decimal Sala { get; set; }
        public decimal Localidad { get; set; }
        public string NomFil { get; set; }
        public decimal FilSil { get; set; }
        public decimal ColSil { get; set; }
        public string ObsSil { get; set; }

        public virtual LocalidadDto LocalidadNavigation { get; set; }
        public virtual ICollection<BoletaDto> Boleta { get; set; }
    }
}
