using Cine.View.Services.ModelDtos;
using System.Collections.Generic;

namespace Cine.View.ViewModel.Movie
{
    public class ReservaDetalle
    {
        public Movie movie { get; set; }
        public List<FuncionDto> funciones { get; set; }
        public string numeroSillasSelected { get; set; }
        public List<string> sillas { get; set; }
        public FuncionDto selectedFuncion { get; set; }


    }
}
