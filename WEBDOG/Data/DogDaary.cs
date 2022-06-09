using System;
using System.ComponentModel.DataAnnotations;

namespace WEBDOG.Data
{
    public class DogDaary
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Собака")]
        public Guid DogId { get; set; }
        public Dog Dog { get; set; }


        //public Person Person { get; set; }

        [Display(Name = "Ветеринар")]
        public Guid? PersonId { get; set; }

        [Display(Name = "Дата вакцинации")]
        public DateTime Date { get; set; }
        
        [Display(Name = "Болезнь")]
        public int Disease { get; set; }

        [Display(Name = "Доза")]
        public int Dose { get; set; }
        
        [Display(Name = "Лекарства")]
        public Drug Drug { get; set; }
        public int DrugId { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }        
    }
}