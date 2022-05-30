using System;
using System.ComponentModel.DataAnnotations;

namespace WEBDOG.Data
{
    public class Drug
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }        

    }
}