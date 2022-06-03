using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBDOG.Models
{
    public class DogModel
    {
        [Key]
        public Guid id { get; set; }

        [Display(Name = "COATO")]
        [Required(ErrorMessage = "Не указан COATO")]
        public int CoatoId { get; set; }
        [Display(Name = "Организация")]
        [Required(ErrorMessage = "Не указан организация")]
        public int OrganizationId { get; set; }

        [Display(Name = "Регистрационный номер")]
        public string TagNumber { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Ф.И.О. владелца")]
        [Required(ErrorMessage = "Не указан владелец")]
        public string Owner { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Не указан адрес")]
        public string Address { get; set; }
        [Display(Name = "Имя собак")]
        [Required(ErrorMessage = "Не заполнен имя собак")]
        public string DogName { get; set; }

        [Display(Name = "Цвет собак")]
        [Required(ErrorMessage = "Не заполнен цвет")]
        public string Colour { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Не заполнен пол собак")]
        public int Gender { get; set; }

        [Display(Name = "Год рождение")]
        [Required(ErrorMessage = "Не заполнен год рождение собак")]
        public int BirthYear { get; set; }

        [Display(Name = "Порода")]
        [Required(ErrorMessage = "Не заполнен порода собак")]
        public string Breed { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Состояние")]
        public int IsAlive { get; set; }

        //public IEnumerable<SelectListItem> Category { get; set; }        
        //public IEnumerable<SelectListItem> Organization { get; set; }
        //public IEnumerable<SelectListItem> Coato { get; set; }
    }
}