namespace Cine.View.Services.ModelDtos
{
    public partial class BoletaDto
    {
        public decimal Id { get; set; }
        public decimal Mapa { get; set; }
        public decimal Funcion { get; set; }
        public decimal Sala { get; set; }
        public decimal Localidad { get; set; }
        public decimal NumSil { get; set; }
        public decimal CodVen { get; set; }
        public decimal SecCliente { get; set; }
        public decimal ValorBolVen { get; set; }

        public virtual VentaDto CodVenNavigation { get; set; }
        public virtual FuncionDto FuncionNavigation { get; set; }
        public virtual LocalidadDto LocalidadNavigation { get; set; }
        public virtual SillaDto NumSilNavigation { get; set; }
        public virtual ClienteDto SecClienteNavigation { get; set; }
    }
}
