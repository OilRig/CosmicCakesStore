using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CosmicCakes.Models
{
    public class OrderModel
    {
        [Required(ErrorMessage = "Как же Вас зовут?")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "И даже телефончик не оставите?")]
        public string CustomerPhoneNumber { get; set; }
        [Required(ErrorMessage = "Не указан вес тортика")]
        [Range(1.5, 100, ErrorMessage = "Минимальный вес - 1,5кг")]
        public double CakeWeight { get; set; }
        public string BisquitType { get; set; }
        public string FillingType { get; set; }
        public string Comments { get; set; }
        public ICollection<string> Berries { get; set; }
        public DateTime ExpireDate { get; set; }
        public OrderModel()
        {
            Berries = new List<string>();
        }
    }
}
