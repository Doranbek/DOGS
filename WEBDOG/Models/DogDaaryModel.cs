using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WEBDOG.Data;

namespace WEBDOG.Models
{
    public class DogDaaryModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
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
        //[Range(typeof(decimal), "0.5", "5")]
        public double Dose { get; set; }

        [Display(Name = "Лекарства")]
        [Required(ErrorMessage = "Не выбрано лекарства")]
        public int DrugId { get; set; }
        //public int Drugspis { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
        public IEnumerable<SelectListItem> Drugspis { get; set; }  

    }
}
