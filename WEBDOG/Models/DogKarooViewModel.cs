using System;
using System.Collections.Generic;
using WEBDOG.Data;

namespace WEBDOG.Models
{
    public class DogKarooViewModel
    {
        public List<DogKaroo> DogKaroos { get; set; }
        public Guid DogId { get; set; }
    }
}
