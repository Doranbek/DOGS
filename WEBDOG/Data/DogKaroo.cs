using System;
using System.ComponentModel.DataAnnotations;

namespace WEBDOG.Data
{
    public class DogKaroo
    {
        [Key]
        public Guid Id { get; set; }
        public Dog Dog { get; set; }
        public Guid DogId { get; set; }
        //public Person Person { get; set; }
        public Guid PersonId { get; set; }
        public DateTime Date { get; set; }
        public int Disease { get; set; }
        public int Weight { get; set; }
        public Drug Drug { get; set; }
        public int DrugId { get; set; }
        public int QuantityDrug { get; set; }
        public string Description { get; set; }
    }
}