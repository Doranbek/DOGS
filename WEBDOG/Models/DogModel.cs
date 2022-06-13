using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static WEBDOG.Data.Enums;

namespace WEBDOG.Models
{
    public class DogModel
    {
        public Guid id { get; set; }

        [Display(Name = "COATO")]
        [Required(ErrorMessage = "Не указан COATO")]
        public int CoatoId { get; set; }
        [Display(Name = "Организация")]
        [Required(ErrorMessage = "Не указан организация")]
        public int OrganizationId { get; set; }

        [Display(Name = "Номер регистрации")]
        [Required(ErrorMessage = "Регистрационный номер не заполнен")]
        public string TagNumber { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Ф.И.О. владелца")]
        public string Owner { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Имя собак")]
        [Required(ErrorMessage = "Не заполнен имя собак")]
        public string DogName { get; set; }

        [Display(Name = "Цвет собак")]
        public string Colour { get; set; }

        [Display(Name = "Пол")]
        [Required(ErrorMessage = "Не заполнен пол собак")]
        public GenderStatus Gender { get; set; }

        [Display(Name = "Год рождение")]
        [Required(ErrorMessage = "Не заполнен год рождение собак")]
        [Range(typeof(int), "2005", "2025")]
        public int BirthYear { get; set; }

        [Display(Name = "Порода")]
        public string Breed { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Состояние")]
        [Required(ErrorMessage = "Состояние собак не выбрано")]
        public LiveStatus IsAlive { get; set; }       
        public IEnumerable<SelectListItem> Organizations { get; set; }
        public IEnumerable<SelectListItem> Coats { get; set; }
    }
}