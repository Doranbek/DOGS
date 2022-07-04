using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEBDOG.Data;

namespace WEBDOG.Models
{
    public class DogDaaryModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public Guid DogId { get; set; }

        [Display(Name = "Дата вакцинацииМодель")]
        [DisplayFormat(DataFormatString="{MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Доза")]
        //[Required(ErrorMessage = "Не указана доза")]
        //[Column(TypeName = "decimal(2,1)")]
        //[Range(1, 2), DataType(DataType.Currency)]
        public decimal Dose { get; set; }

        [Display(Name = "Лекарства")]
        [Required(ErrorMessage = "Не выбрано лекарства")]
        public int DrugId { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
        public List<SelectListItem> ListDrugIdOff { get; set; }


    }
}
