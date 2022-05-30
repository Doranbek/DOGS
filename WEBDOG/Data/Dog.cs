using System;
using System.ComponentModel.DataAnnotations;

namespace WEBDOG.Data
{
    public class Dog
    {
        [Key]
        public Guid id { get; set; }
        public Coato Coato { get; set; }
        public int CoatoId { get; set; }
        public Organization Organization { get; set; }
        public int OrganizationId { get; set; }
        public string TagNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Owner { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string DogName { get; set; }
        public string Colour { get; set; }
        public int Gender { get; set; }
        public int BirthYear { get; set; }
        public string Breed { get; set; }
        public string Description { get; set; }
        public int IsAlive { get; set; }
    }
}