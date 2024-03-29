﻿using System;
using System.ComponentModel.DataAnnotations;
using static WEBDOG.Data.Enums;

namespace WEBDOG.Data
{
    public class Drug
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "серийный номер")]
        public string SerialNumber { get; set; }

        [Display(Name = "срок годности")]

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Болезнь")]
        public string Disease { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}