using System.ComponentModel.DataAnnotations;

namespace WEBDOG.Data
{
    public class Organization
    {
        [Required]
        public int id { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public string Login { get; set; }

    }
}