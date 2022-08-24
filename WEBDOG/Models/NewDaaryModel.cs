using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEBDOG.Data;

namespace WEBDOG.Models
{
    public class NewDaaryModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
       
        [Display(Name = "Регистрационный номер собак")]
        public string TagNumber { get; set; }

        [Display(Name = "Дата вакцинацииМодель")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Доза")]
        //[Required(ErrorMessage = "Не указана доза")]
        [Column(TypeName = "decimal(1,99)")]
        //[DisplayFormat(DataFormatString = @"{0:1.1}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"^(\d+),(\d{2})$", ErrorMessage = "Доза от 1,00 до 2 на одну собаку за год. ")]
        [Range(0.5, 2, ErrorMessage = "Допустимая доза для собаки от 0.5 до 2")]
        public decimal Dose { get; set; }

        [Display(Name = "Лекарства")]
        [Required(ErrorMessage = "Не выбрано лекарства")]
        public int DrugId { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
        public List<SelectListItem> ListDrugIdOff { get; set; }
    }
}
