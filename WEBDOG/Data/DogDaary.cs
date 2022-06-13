using System;
using System.ComponentModel.DataAnnotations;

namespace WEBDOG.Data
{
    public class DogDaary
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        //[Display(Name = "Собака")]
        public Guid DogId { get; set; }

        [Display(Name = "Дата вакцинации")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Доза")]
        public double Dose { get; set; }

        [Required]
        [Display(Name = "Лекарства")]
        public int DrugId { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }        
    }
}