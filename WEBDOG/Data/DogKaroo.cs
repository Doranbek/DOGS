using System;
using System.ComponentModel.DataAnnotations;

namespace WEBDOG.Data
{
    public class DogKaroo
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Собака")]
        public Guid DogId { get; set; }
     
        
        [Display(Name = "Дата дегельминтизаци")]
        public DateTime Date { get; set; }

        [Display(Name = "Лекарства")]
        public int DrugId { get; set; }

        [Display(Name = "Весь")]
        public int Weight { get; set; }


        [Display(Name = "Колличество таблеток")]
        public int QuantityDrug { get; set; }


        [Display(Name = "Описание")]
        public string Description { get; set; }

    }
}