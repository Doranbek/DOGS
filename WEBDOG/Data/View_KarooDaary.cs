using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WEBDOG.Data.Enums;

namespace WEBDOG.Data
{
    [Table(name: "View_KarooDaarys")]
    public class View_KarooDaary
    {
        [Key]
        public Guid DogId { get; set; }

        [Display(Name = "Организация")]
        public string OrdName { get; set; }

        [Display(Name = "Аймак")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Номер регистрации")]
        public string TagNumber { get; set; }

        [Display(Name = "Tелефон")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Ф.И.О. владелца")]
        public string Owner { get; set; }

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

        [Display(Name = "Дата создания")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Range(typeof(int), "2005", "2025")]
        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Состояние собаки")]
        public LiveStatus IsAlive { get; set; }

        [Display(Name = "Дата снятие из БД")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DateOfDeath { get; set; }

        [Display(Name = "Год лечении")]
        public int myear { get; set; }

        [Display(Name = "I квартал")]
        public Status QvartK1 { get; set; }

        [Display(Name = "II квартал")]
        public Status QvartK2 { get; set; }

        [Display(Name = "III квартал")]
        public Status QvartK3 { get; set; }

        [Display(Name = "IV квартал")]
        public Status QvartK4 { get; set; }

        [Display(Name = "Весь собак")]
        public int SumWeght { get; set; }

        [Display(Name = "Количество таблеток")]
        public decimal KolTab { get; set; }

        public int OrganizationId { get; set; }
        public int CoatoId { get; set; }

        [Display(Name = "Год вакцинации")]
        [Range(typeof(int), "2005", "2025")]
        public int? Expr1 { get; set; }

        [Display(Name = "I квартал")]
        public Status? Qvar1 { get; set; }

        [Display(Name = "II квартал")]
        public Status? Qvar2 { get; set; }

        [Display(Name = "III квартал")]
        public Status? Qvar3 { get; set; }

        [Display(Name = "IV квартал")]
        public Status? Qvar4 { get; set; }

        [Display(Name = "Доза")]
        public decimal? DoseSum { get; set; }
    }
}
