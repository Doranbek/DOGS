using System;
using System.ComponentModel.DataAnnotations;


namespace WEBDOG.Models
{
    public class DogKarooModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public Guid DogId { get; set; }

        [Display(Name = "Дата дегельминтизации")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Весь")]
        [Required(ErrorMessage = "Не указано весь")]
        public int Weight { get; set; }

        [Display(Name = "Колличество доз")]
        [Required(ErrorMessage = "Не указана доза")]
        public decimal QuantityDrug { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

    }
}
