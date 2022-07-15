using System;
using System.ComponentModel.DataAnnotations;

namespace WEBDOG.Data
{
    public class DogKarooNew
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Собака")]
        public Guid DogId { get; set; }

        [Display(Name = "Дата дегельминтизацииNEW")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Лекарство")]
        public int DrugId { get; set; }

        [Display(Name = "Весь")]
        public int Weight { get; set; }

        [Display(Name = "Колличество таблеток")]
        public decimal QuantityDrug { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}

