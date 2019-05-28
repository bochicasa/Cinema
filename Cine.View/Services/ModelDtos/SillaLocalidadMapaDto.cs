namespace Cine.View.Services.ModelDtos
{
    public class SillaLocalidadMapaDto
    {
        public decimal Id { get; set; }
        public decimal Localidad { get; set; }
        public decimal NumSil { get; set; }
        public decimal Mapa { get; set; }
        public decimal Estado { get; set; }

        public virtual LocalidadDto LocalidadNavigation { get; set; }
        
    }
}
