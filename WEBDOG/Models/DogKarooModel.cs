﻿using System;
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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Весь")]
        [Required(ErrorMessage = "Не указано весь")]
        [Range(1, 150, ErrorMessage = "Максимальный вес собаки 150 кг")]
        public int Weight { get; set; }

        [Display(Name = "Колличество таблеток")]
        [Required(ErrorMessage = "Не указана доза")]
        [Range(1, 15, ErrorMessage = "Допустимая количество таблеток на 10 кг=1 штук")]
        public decimal QuantityDrug { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

    }
}
