using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WEBDOG.Data.Enums;

namespace WEBDOG.Data
{
    [Table(name: "ViewDogs")]
    public class ViewDog
    {
        [Key]
        public Guid id { get; set; }

        [Display(Name = "Аймак")]
        public string CoatoId { get; set; }

        [Display(Name = "Организация")]
        public int OrganizationId { get; set; }

        [Required]
        [Display(Name = "Номер регистрации")]
        public string TagNumber { get; set; }

        [Display(Name = "Дата создания")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? CreatedDate { get; set; }

        [Required]
        [Display(Name = "Ф.И.О. владелца")]
        public string Owner { get; set; }

        [Display(Name = "Tелефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Имя собак")]
        public string DogName { get; set; }

        [Display(Name = "Цвет собак")]
        public string Colour { get; set; }

        [Display(Name = "Пол собаки")]
        public GenderStatus Gender { get; set; }

        [Display(Name = "Год рождение")]
        public int BirthYear { get; set; }

        [Display(Name = "Порода")]
        public string Breed { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Состояние собаки")]
        public LiveStatus IsAlive { get; set; }
    }
}
