using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static WEBDOG.Data.Enums;

namespace WEBDOG.Models
{
    public class DrugModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Не указан названия")]
        public string Name { get; set; }
        [Display(Name = "серийный номер")]
        [Required(ErrorMessage = "Не указан серийный номер")]
        public string SerialNumber { get; set; }
        
        [Display(Name = "срок годности")]
        [Required(ErrorMessage = "Не указан срок годност")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Болезнь")]
        public string Disease { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
        public List<SelectListItem> Drugs { get; set; }
    }
}
