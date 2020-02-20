using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Knewin.Domain.Entities
{
    public class Cidade : BaseEntity
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public double Habitantes { get; set; }
        public virtual List<Cidade> Fronteiras { get; set; } = new List<Cidade>();
    }
}
