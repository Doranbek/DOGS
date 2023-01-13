using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WEBDOG.Data;

namespace WEBDOG.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Coato> coatos, int? coatsin)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            coatos.Insert(0, new Coato { Name = "Все", Id = 0 });
            Companies = new SelectList(coatos, "Id", "Name", coatsin);
            SelectedCompany = coatsin;
            
        }
        public SelectList Companies { get; private set; } // список компаний
        public int? SelectedCompany { get; private set; }   // выбранная компания
       
    }
}
