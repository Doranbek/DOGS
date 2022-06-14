using System.ComponentModel.DataAnnotations;

namespace WEBDOG.Data
{
    public class Coato
    {
        [Key]
        public int Id { get; set; }
        public int Parent { get; set; }
        public string CoatoNum { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}