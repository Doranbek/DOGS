using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBDOG.Data
{
    [Table(name: "View_SvodDaarys")]
    public class View_SvodDaary
    {
        [Key]
        [Display(Name = "Год лечении")]
        //[Range(typeof(int), "2005", "2025")]
        public int Expr1 { get; set; }

        [Display(Name = "Организация")]
        public string OrdName { get; set; }

        [Display(Name = "Количество собак")]
        public int kolSobak { get; set; }

        [Display(Name = "I квартал")]
        public int QvarK1 { get; set; }

        [Display(Name = "II квартал")]
        public int QvarK2 { get; set; }

        [Display(Name = "III квартал")]
        public int QvarK3 { get; set; }

        [Display(Name = "IV квартал")]
        public int QvarK4 { get; set; }

        [Display(Name = "Доза")]
        public decimal KolDos { get; set; }
    }
}

