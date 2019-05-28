using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.View.ViewModel.Movie
{
    public class Rootobject
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public Movie[] results { get; set; }
    }


}
