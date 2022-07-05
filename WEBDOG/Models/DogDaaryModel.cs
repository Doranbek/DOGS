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
        [Column(TypeName = "decimal(1,1)")]
        [DisplayFormat(DataFormatString = @"{0:0.0}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"^(\d+),(\d{2})$", ErrorMessage = "Доза от 1,00 до 2 на одну собаку за год. ")]
        [Range(0.4, 2)]
        public decimal Dose { get; set; }

        [Display(Name = "Лекарства")]
        [Required(ErrorMessage = "Не выбрано лекарства")]
        public int DrugId { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
        public List<SelectListItem> ListDrugIdOff { get; set; }


    }
}
