using System.ComponentModel.DataAnnotations;

namespace Knewin.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
