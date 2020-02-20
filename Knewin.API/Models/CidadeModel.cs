using System.ComponentModel.DataAnnotations;

namespace Knewin.API.Models
{
    public class CidadeModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public double Habitantes { get; set; }
        public int[] Fronteiras { get; set; }
    }
}