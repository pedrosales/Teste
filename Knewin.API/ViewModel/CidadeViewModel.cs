using System.Collections.Generic;

namespace Knewin.API.ViewModels.CidadeViewModel
{
    public class CidadeViewModel
    {
        public string Nome { get; set; }
        public double Habitantes { get; set; }
        public IEnumerable<CidadeViewModel> Fronteiras { get; set; }
    }
}