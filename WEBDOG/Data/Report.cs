using System;
using System.ComponentModel.DataAnnotations;

namespace WEBDOG.Data
{
    public class Report
    {
        [Key]
        public int Id  { get; set; }

        [Display(Name = "Организация")]
        public Organization Organization { get; set; }
        public int OrganizationId  { get; set; }

        [Display(Name = "Лекарство")]
        public Drug Drug { get; set; }
        public int DrugId { get; set; }

        [Display(Name = "Колличество")]
        public int Count { get; set; }

        [Display(Name = "Дата создания")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? CreatedDate { get; set; }
    }
}
