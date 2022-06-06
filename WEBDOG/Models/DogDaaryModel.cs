using System;
using System.ComponentModel.DataAnnotations;
using WEBDOG.Data;

namespace WEBDOG.Models
{
    public class DogDaaryModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Display(Name = "Собака")]
        [Required(ErrorMessage = "Не указана собака")]
        public Dog Dog { get; set; }
        public Guid DogId { get; set; }
        //public Person Person { get; set; }
        [Display(Name = "Ветеринар")]
        public Guid PersonId { get; set; }
        [Display(Name = "Дата вакцинации")]
        public DateTime Date { get; set; }

        [Display(Name = "Болезнь")]
        [Required(ErrorMessage = "Не указан болезнь")]
        public int Disease { get; set; }

        [Display(Name = "Доза")]
        [Required(ErrorMessage = "Не указана доза")]
        public int Dose { get; set; }

        [Display(Name = "Лекарства")]
        [Required(ErrorMessage = "Не выбрано лекарства")]
        public Drug Drug { get; set; }
        public int DrugId { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
