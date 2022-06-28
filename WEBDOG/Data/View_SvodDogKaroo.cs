using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WEBDOG.Data.Enums;

namespace WEBDOG.Data
    
{
    [Table(name: "View_SvodDogKaroo")]
    public class View_SvodDogKaroo
    {
        [Display(Name = "Организация")]
        public string OrdName { get; set; }

        [Display(Name = "Количество собак")]
        public int kolSobak { get; set; }

        [Key]
        [Display(Name = "Год вакцинации")]
        public int myear { get; set; }

        [Display(Name = "I квартал")]
        public int QvartK1 { get; set; }

        [Display(Name = "II квартал")]
        public int QvartK2 { get; set; }

        [Display(Name = "III квартал")]
        public int QvartK3 { get; set; }

        [Display(Name = "IV квартал")]
        public int QvartK4 { get; set; }
        public int srKolTab { get; set; }
    }
}
