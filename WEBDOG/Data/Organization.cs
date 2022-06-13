using System.ComponentModel.DataAnnotations;

namespace WEBDOG.Data
{
    public class Organization
    {
        [Required]
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }

    }
}