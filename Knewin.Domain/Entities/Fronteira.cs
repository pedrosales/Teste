namespace Knewin.Domain.Entities
{
    public class Fronteira : BaseEntity
    {
        public Cidade Cidade1 { get; set; }
        public Cidade Cidade2 { get; set; }
    }
}
