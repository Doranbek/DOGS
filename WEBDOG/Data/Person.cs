using System;
using System.ComponentModel.DataAnnotations;

namespace WEBDOG.Data
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "COATO")]
        public Coato Coato { get; set; }
        public int CoatoId { get; set; }

        [Display(Name = "Ф.И.О")]
        public string FullName { get; set; }

        [Display(Name = "Пол")]
        public int Gender { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime? BirthDay { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Серия паспорта")]
        public string PassportNumber { get; set; }

        [Display(Name = "Срок выдачи")]
        public DateTime? DateOfIssue { get; set; }

        [Display(Name = "Выдан")]
        public string IssuingOrg { get; set; }
        
        [Display(Name = "ПИН")]
        public string TagNumber { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }
        
        [Display(Name = "Университет")]
        public string University { get; set; }

        [Display(Name = "Специальность")]
        public string Specialization { get; set; }
    }
}