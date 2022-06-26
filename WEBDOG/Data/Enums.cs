using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace WEBDOG.Data
{
    public class Enums
    {
        public enum GenderStatus
        {
            Кобель = 1,
            Сука =2,
            Неизвестно =3
        }
        public enum LiveStatus
        {
            Жив = 1,
            Умер = 2,
            Больная
        }

        public enum Status
        {            
            да = 1,
            нет = 0
        }
    }
}
