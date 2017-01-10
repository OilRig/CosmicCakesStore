using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CosmicCakesWebApp.Models
{
    public class OrderModel
    {
        [Required(ErrorMessage = "Как же Вас зовут?")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "И даже телефончик не оставите?")]
        public string CustomerPhoneNumber { get; set; }
        [Required(ErrorMessage = "Не указан вес тортика")]
        [Range(1.5, 12, ErrorMessage = "Минимальный вес - 1.5кг,а максимальный - 12 кг")]
        public double CakeWeight { get; set; }
        public string BisquitType { get; set; }
        public string FillingType { get; set; }
        public string Comments { get; set; }
        public ICollection<string> Berries { get; set; }
        [Required(ErrorMessage = "Кажется,Вы не указали дату для тортика")]
        public DateTime ExpireDate { get; set; }
        public OrderModel()
        {
            Berries = new List<string>();
        }
        public override string ToString()
        {
            var berries = "";
            foreach (var berry in Berries)
                berries += berry + ",";
            return string.Format(" Заказ от: {0} \n Телефон: {1} \n Дата: {2} \n Вес: {3} кг \n Бисквит: {4} \n Начинка: {5} \n Ягоды: {6} \n Комментарий: {7}", CustomerName,
                CustomerPhoneNumber, ExpireDate.ToShortDateString(), CakeWeight, BisquitType, FillingType, berries, Comments);
        }
    }
}
