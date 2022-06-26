using System.Collections.Generic;
using WEBDOG.Data;

namespace WEBDOG.Models
{

        public class IndexViewModel
        {
            public IEnumerable<ViewDog> ViewDogs { get; set; }
            public PageViewModel PageViewModel { get; set; }
        }
    
}
