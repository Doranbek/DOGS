using System;
using System.ComponentModel.DataAnnotations;

namespace WEBDOG.Data
{
    public class Dog
    {
        [Key]
        public Guid id { get; set; }

        [Display(Name = "COATO")]      
        public int CoatoId { get; set; }
        public Coato Coato { get; set; }

        [Display(Name = "Организация")]        
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [Required]
        [Display(Name = "Регистрационный номер")]
        public string TagNumber { get; set; }

        [Display(Name = "Дата создания")]
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
                
        [Display(Name = "Пол")]
        public int Gender { get; set; }

        [Display(Name = "Год рождение")]
        public int BirthYear { get; set; }

        [Display(Name = "Порода")]
        public string Breed { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Состояние")]
        public int IsAlive { get; set; }
    }
}