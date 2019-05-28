using System;

namespace Cine.View.Services.ModelDtos
{
    public partial class ReservaDto
    {
        public decimal Id { get; set; }
        public decimal Funcion { get; set; }
        public decimal NumSil { get; set; }
        public DateTime FechaRes { get; set; }
        public string TipoRes { get; set; }
        public decimal SecCliente { get; set; }
        public string Estado { get; set; }
        public decimal SillaLocalidad { get; set; }

        public virtual FuncionDto FuncionNavigation { get; set; }
        public virtual ClienteDto SecClienteNavigation { get; set; }
        public virtual SillaLocalidadMapaDto SillaLocalidadNavigation { get; set; }
    }
}
