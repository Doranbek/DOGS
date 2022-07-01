using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBDOG.Data
{
    public class DogDaary
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Собака")]
        public Guid DogId { get; set; }
        protected internal string NameDar { get; set; }

        [Display(Name = "Дата вакцинации")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        //[Required]
        [Display(Name = "Доза")]
        [Column(TypeName = "decimal(2,1)")]
        public decimal Dose { get; set; }

        [Required]
        [Display(Name = "Лекарства")]
        public int DrugId { get; set; }        

        [Display(Name = "Описание")]
        public string Description { get; set; }        
    }
}